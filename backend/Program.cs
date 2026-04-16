using Microsoft.EntityFrameworkCore;
// Zostaw tutaj swoje u góry (np. using CloudBackend.Models; using CloudBackend.Data;)

var builder = WebApplication.CreateBuilder(args);

// Bezpośrednie połączenie z bazą (z nowym hasłem)
var connectionString = "Server=tcp:cloud-app-db-94570.database.windows.net,1433;Initial Catalog=cloud-app-db-94570;Persist Security Info=False;User ID=admindb;Password=cde3xsW@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// --- MAGIA SEEDOWANIA (DODAWANIE ZADAŃ FABRYCZNYCH) ---
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    // Sprawdzamy czy baza jest pusta (użyj nazwy swojego modelu, jeśli jest inna niż 'Task')
    if (!db.Tasks.Any())
    {
        db.Tasks.AddRange(
            new Task { Title = "Wypić mocną kawę ☕", IsCompleted = false },
            new Task { Title = "Wygrać walkę z chmurą Azure ☁️", IsCompleted = true },
            new Task { Title = "Zdać projekt na 5.0! 🏆", IsCompleted = false }
        );
        db.SaveChanges();
    }
}
// -------------------------------------------------------

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();