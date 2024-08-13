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
        await CreateHostBuilder(args, b => ConfigureWebHostBuilder(b))
            .Build()
            .RunAsync();
        
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

