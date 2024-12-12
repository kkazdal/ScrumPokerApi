using AspNetCoreRateLimit;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Services;
using ScrumPoker.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Bağlantı dizesini çek
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// DbContext'i hizmet olarak ekle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Diğer servis kayıtları
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSaveApplicationService(builder.Configuration);//Mediator için dependency injection yapıldı

builder.Services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations(); // Swagger açıklamalarını etkinleştirin
        });

builder.Services.AddMemoryCache();

builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.Configure<IpRateLimitOptions>(options =>
{
    options.GeneralRules = new List<RateLimitRule>
    {
        new RateLimitRule
        {
            Endpoint = "*",
            Period = "1m", // Dakikada 1 kez
            Limit = 50 // Dakikada en fazla 50 istek
        }
    };
});
builder.Services.AddInMemoryRateLimiting(); // In-memory rate limiting için
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>(); // MemoryCache kullanarak sayaç depolama
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>(); // İsteğe bağlı işlem stratejisi

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapControllers(); // Controller rotalarını uygulamaya dahil eder

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
