using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace Forpost.Web.Host;

internal sealed class Program
{
    public static async Task Main(string[] args)
    {
        ConfigureLogger();
        Log.Information("Сервис запущен");

        var host =  CreateHostBuilder(args, b => ConfigureWebHostBuilder(b))
            .Build();
        await Task.Delay(1000);
        
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ForpostContextPostgres>();
                await context.Database.MigrateAsync(); // Выполнение миграций
                await StartMirgation.StartMigrationWithTestData(context); // Генерация тестовых данных
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при выполнении стартовой миграции: {0}", ex);
            }
        }
        
        await host.RunAsync();


        
    }

    private static IHostBuilder CreateHostBuilder(string[] args, Action<IWebHostBuilder> webHostBuilderConfigurator)
        => Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder()
            .UseSerilog()
            .ConfigureWebHostDefaults(webHostBuilderConfigurator);

    private static IWebHostBuilder ConfigureWebHostBuilder(IWebHostBuilder webHostBuilder)
        => webHostBuilder
            .UseStartup<Startup>();
    
    private static void ConfigureLogger()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Seq("http://localhost:5341") // URL для Seq
            .CreateBootstrapLogger();
    }

    
}

