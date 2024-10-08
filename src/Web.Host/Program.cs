using Forpost.Store.Migrations;
using Forpost.TelegramBot;

namespace Forpost.Web.Host;

internal sealed class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args, ConfigureWebHostBuilder).Build();
        var logger = host.Services.GetRequiredService<ILogger<Program>>();
        var configuration = host.Services.GetRequiredService<IConfiguration>();

        try
        {
            logger.LogDebug("Старт миграции БД ErpDatabase");
            await MigrationManager.MigrateSchema(configuration);
            logger.LogDebug("Миграция схемы произошла успешно!");
            logger.LogDebug("Старт миграции данных");
            await MigrationManager.MigrateData(configuration);
            logger.LogDebug("Старт миграции прошла успешно");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Не удалось выполнить миграцию.");
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