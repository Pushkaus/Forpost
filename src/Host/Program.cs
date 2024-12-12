using Forpost.Host;
using static Forpost.Store.Migrations.MigrationManager;

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
            if (args.Contains("--with-schema-migration"))
            {
                logger.LogDebug("Старт миграции схемы БД ErpDatabase");
                await MigrateSchema(configuration);
                logger.LogDebug("Миграция схемы произошла успешно!");
            }

            if (args.Contains("--with-data-migration"))
            {
                logger.LogDebug("Старт миграции данных БД ErpDatabase");
                await MigrateData(configuration);
                logger.LogDebug("Миграция данных прошла успешно!");
            }
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
            .CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.Configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT");

                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true);
            })
            .ConfigureWebHostDefaults(webHostBuilderConfigurator);
    }
    private static void ConfigureWebHostBuilder(IWebHostBuilder webHostBuilder) => webHostBuilder.UseStartup<Startup>();
}