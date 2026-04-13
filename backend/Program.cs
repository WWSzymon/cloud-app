using Microsoft.EntityFrameworkCore;
using CloudBackend.Data;
using CloudBackend.Models;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// --- SEKCJA 1: INTEGRACJA Z AZURE KEY VAULT ---
// Wykonywana tylko, gdy aplikacja działa w trybie Production (w chmurze Azure)
if (builder.Environment.IsProduction())
{
    // Pobiera nazwę sejfu ze Zmiennych środowiskowych (KeyVaultName)
    var vaultName = builder.Configuration["KeyVaultName"];
    if (!string.IsNullOrEmpty(vaultName))
    {
        var keyVaultEndpoint = new Uri($"https://{vaultName}.vault.azure.net/");
        // Wykorzystuje Tożsamość Zarządzaną do bezpiecznego dostępu bez haseł
        builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
    }
}

// --- SEKCJA 2: REJESTRACJA USŁUG (Dependency Injection) ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Logika pobierania Connection Stringa:
// 1. Najpierw szuka "DbConnectionString" (nazwa z Twojego Key Vaulta)
// 2. Jeśli nie znajdzie, szuka "DefaultConnection" (z pliku appsettings.json)
var connectionString = builder.Configuration["DbConnectionString"] 
                       ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString,
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null)
    ));

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// --- SEKCJA 3: AUTOMATYCZNE DANE STARTOWE ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        // Dodaje zadania do bazy, jeśli tabela jest pusta
        if (!context.Tasks.Any())
        {
            context.Tasks.AddRange(
                new CloudTask { Name = "Zrobić kawę", IsCompleted = true },
                new CloudTask { Name = "Zabezpieczyć aplikację w Azure", IsCompleted = true }
            );
            context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        // Wyświetli błąd w "Log stream" jeśli połączenie z bazą nie zadziała
        Console.WriteLine($"Błąd inicjalizacji bazy danych: {ex.Message}");
    }
}

// --- SEKCJA 4: POTOK HTTP (Middleware) ---
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cloud API V1");
    // Dzięki temu Swagger pojawi się od razu po wejściu na stronę główną backendu
    c.RoutePrefix = string.Empty; 
});

app.UseCors();
app.MapControllers();

app.Run();