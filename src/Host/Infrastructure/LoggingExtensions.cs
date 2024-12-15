using Microsoft.Extensions.Logging.Console;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;

namespace Forpost.Host.Infrastructure;

internal static class LoggingExtensions
{
    internal static IServiceCollection AddOpenTelemetryLogging(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddLogging(logging => logging

            .AddSimpleConsole(options =>
            {
                options.ColorBehavior = LoggerColorBehavior.Enabled;
                options.IncludeScopes = true;
                options.SingleLine = true;
                options.TimestampFormat = "HH:mm:ss ";
            })

            .AddOpenTelemetry(options => options
                .SetResourceBuilder(ResourceBuilder.CreateEmpty()
                    .AddService(HostConstants.Name))
                .AddOtlpExporter(exporter =>
                {
                    exporter.Protocol = OtlpExportProtocol.HttpProtobuf;
                    exporter.Endpoint = configuration.GetValue<Uri>("Seq:ServerUri") ??
                                        throw new AggregateException("Не указан Seq:ServerUri");
                    exporter.Headers = $"X-Seq-ApiKey={configuration.GetValue<string>("Seq:ApiKey")}";
                })));
        return services;
    }
}