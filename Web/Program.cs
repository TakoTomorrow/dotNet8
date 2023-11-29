using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyDataBases.FundationDbContext;
using MyDataBases.FundationDbContext.Models;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Initial Application.");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
        .AddIdentityCookies();
    builder.Services.AddAuthorizationBuilder();
    builder.Services.AddDbContext<FundationDbContext>(
        options => options.UseSqlServer("AppDb"));


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapIdentityApi<MyUser>();
    app.UseHttpsRedirection();

    var summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

    // 網站啟動
    app.Run();
}
catch (Exception ex)
{
    // 捕獲設定錯誤的錯誤紀錄
    logger.Error(ex, "Stopped program because of exception");
}
finally
{
    logger.Debug("Shutdown Application");

    //須確定在關閉時，把nlog關閉
    LogManager.Shutdown();
}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}