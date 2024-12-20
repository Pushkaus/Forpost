using Forpost.Common.ApplicationNotifications;
using Forpost.Domain;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Host;

/// <summary>
/// Сервис инициализации уведомлений при старте приложения
/// </summary>\
// TODO: переделать на QUARTZ (в BackgroundJob) и удалить TelegramBot.csproj
public class ApplicationNotificationInitializer: IHostedService
{
    private readonly IServiceProvider _serviceProvider;
        
    public ApplicationNotificationInitializer(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ForpostContextPostgres>();
                
            var notificationTypes = DomainAssemblyReference.Assembly
                .GetTypes()
                .Where(t => typeof(IApplicationNotification).IsAssignableFrom(t) 
                            && t is { IsInterface: false, IsAbstract: false })
                .ToList();

            foreach (var notificationName in notificationTypes.Select(type => type.Name))
            {
                var exists = await context.ApplicationNotifications
                    .AnyAsync(n => n.NotificationName == notificationName, cancellationToken);

                if (!exists)
                {
                    var appNotification = new ApplicationNotification
                    {
                        NotificationName = notificationName,
                    };

                    context.ApplicationNotifications.Add(appNotification);
                }
            }

            await context.SaveChangesAsync(cancellationToken);
        }
    }
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}