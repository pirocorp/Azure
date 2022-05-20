namespace SimpleApi;

using System;
using System.Linq;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public static class Program
{
    private const string InstrumentationKey = "82e38870-19f3-403c-88e4-871c967383ef";

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureConfiguration(builder.Configuration);
        ConfigureServices(builder.Services);

        var app = builder.Build();
        
        ConfigureMiddleware(app, app.Services);
        ConfigureEndpoints(app, app.Services);
        
        app.Run();
    }

    private static void ConfigureConfiguration(ConfigurationManager builderConfiguration)
    {
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddApplicationInsightsTelemetry(InstrumentationKey);
    }

    private static void ConfigureMiddleware(IApplicationBuilder app, IServiceProvider services)
    {
    }

    private static void ConfigureEndpoints(WebApplication app, IServiceProvider services)
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/weatherforecast", () =>
        {
            var forecast = Enumerable
                .Range(1, 1)
                .Select(index =>
                {
                    var summaryId = Random.Shared.Next(summaries.Length);
                    LogWeather(app, summaryId);

                    return new WeatherForecast
                    (
                        DateTime.Now.AddDays(index),
                        Random.Shared.Next(-20, 55),
                        summaries[summaryId]
                    );
                })
                .ToArray();

            return forecast;
        });
    }

    private static void LogWeather(WebApplication app, int summaryId)
    {
        switch (summaryId)
        {
            case 0: case 9:
                app.Logger.LogError("WeatherForecast: extreme weather");
                break;
            case 1: case 2: case 7: case 8:
                app.Logger.LogWarning("WeatherForecast: severe weather");
                break;
            default:
                app.Logger.LogInformation("WeatherForecast: mild weather");
                break;
        }
    }
}

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}