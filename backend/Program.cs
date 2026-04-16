using Microsoft.EntityFrameworkCore;
using CloudBackend.Data; // Upewnij się, że ta przestrzeń nazw pasuje do Twojego projektu

var builder = WebApplication.CreateBuilder(args);

// --- BEZPOŚREDNIE POŁĄCZENIE Z BAZĄ (OMINIĘCIE KEY VAULT) ---
var connectionString = "Server=tcp:cloud-app-db-94570.database.windows.net,1433;Initial Catalog=cloud-app-db-94570;Persist Security Info=False;User ID=admindb;Password=cde3xsW@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
// -----------------------------------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Automatyczne tworzenie bazy i tabel przy starcie
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();