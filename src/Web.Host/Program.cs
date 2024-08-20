using Forpost.Store.Postgres;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

namespace Forpost.Web.Host;

internal sealed class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args, b => ConfigureWebHostBuilder(b))
            .Build();

        var configuration = host.Services.GetRequiredService<IConfiguration>();

        ConfigureLogger(configuration);

        Log.Information("Сервис запущен");

        await Task.Delay(1000);

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ForpostContextPostgres>();
                var logger = services.GetRequiredService<ILogger<Program>>();
                //await context.Database.MigrateAsync();
                //await Mirgation.StartMigrationWithFirstUser(context, logger);
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка при выполнении стартовой миграции: {ex}", ex);
            }
        }

        await host.RunAsync();
    }

    private static IHostBuilder CreateHostBuilder(string[] args, Action<IWebHostBuilder> webHostBuilderConfigurator)
    {
        return Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder()
            .UseSerilog()
            .ConfigureWebHostDefaults(webHostBuilderConfigurator);
    }

    private static IWebHostBuilder ConfigureWebHostBuilder(IWebHostBuilder webHostBuilder)
    {
        return webHostBuilder
            .UseStartup<Startup>();
    }

    private static void ConfigureLogger(IConfiguration configuration)
    {
        var serverUrl = configuration["Serilog:WriteTo:0:Args:serverUrl"];
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Seq(serverUrl)
            .WriteTo.Console()
            .CreateBootstrapLogger();
    }
}