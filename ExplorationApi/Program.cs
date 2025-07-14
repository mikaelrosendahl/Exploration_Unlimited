using Microsoft.EntityFrameworkCore;
using ExplorationApi.Data;




var builder = WebApplication.CreateBuilder(args);

// Lägg till tjänster för beroendeinjektion
builder.Services.AddControllers();

// Konfigurera inställningar från appsettings.json och miljövariabler
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();  // viktigt för att kunna läsa Render-miljövariabler

// Hämta connection string från konfigurationen (miljövariabler övertrumfar json)
var diaryConnectionString = builder.Configuration.GetConnectionString("DiaryConnection");

// Kontrollera att connection string är satt, annars kasta fel tidigt
if (string.IsNullOrEmpty(diaryConnectionString))
{
    throw new Exception("DiaryConnection string is not configured.");
}

// Om miljö inte är satt, defaulta till "Local"
if (string.IsNullOrEmpty(builder.Environment.EnvironmentName))
{
    builder.Environment.EnvironmentName = "Local";
}

// Lägg till DiaryDbContext för att hantera dagboksinlägg
builder.Services.AddDbContext<DiaryDbContext>(options =>
    options.UseNpgsql(diaryConnectionString)
);

// CORS-policy
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendDev", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
Console.WriteLine("CORS origins: " + string.Join(", ", allowedOrigins));

// Swagger och andra tjänster
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrEmpty(port))
{
    builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
}

var app = builder.Build();

app.UseRouting();


app.UseCors("AllowFrontendDev");

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
