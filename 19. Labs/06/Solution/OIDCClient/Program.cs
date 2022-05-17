namespace OIDCClient;

using System;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

public static class Program
{
    private static IConfigurationSection? azureAdConfig;

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

    private static void ConfigureConfiguration(IConfiguration configuration)
    {
        azureAdConfig = configuration.GetSection("AzureAd");
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.
        services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(azureAdConfig ?? throw new InvalidOperationException("Missing AD configuration"));

        services.AddControllersWithViews(options =>
        {
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            options.Filters.Add(new AuthorizeFilter(policy));
        });

        services.AddRazorPages().AddMicrosoftIdentityUI();
    }

    private static void ConfigureMiddleware(WebApplication app, IServiceProvider services)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
    }

    private static void ConfigureEndpoints(IEndpointRouteBuilder app, IServiceProvider services)
    {
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapRazorPages();
    }
}
