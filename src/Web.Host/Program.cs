using Forpost.Store.Postgres;

namespace Forpost.Web.Host;

internal sealed class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args, ConfigureWebHostBuilder).Build();
        var logger = host.Services.GetRequiredService<ILogger<Program>>();
        
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ForpostContextPostgres>();
                
                logger.LogDebug("Старт миграции БД ErpDatabase");
                await MigrationManager.MigrateSchema(context); 
                logger.LogDebug("Миграция схемы произошла успешно!");
                logger.LogDebug("Старт миграции данных");
                await MigrationManager.MigrateData(context);
                logger.LogDebug("Старт миграции прошла успешно");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Не удалось выполнить миграцию.");
            }
        }

        await host.RunAsync();
    }

    private static IHostBuilder CreateHostBuilder(string[] args, Action<IWebHostBuilder> webHostBuilderConfigurator)
    {
        return Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder()
            .ConfigureWebHostDefaults(webHostBuilderConfigurator);
    }

    private static void ConfigureWebHostBuilder(IWebHostBuilder webHostBuilder) => webHostBuilder.UseStartup<Startup>();
}