using Forpost.Domain.MessagesManagement.ApplicationNotifications;
using Mediator;

namespace Forpost.Features.MessageManagement.ApplicationNotifications.ApplicationUserNotifications;

internal sealed class AddUserNotificationCommandHandler: ICommandHandler<AddUserNotificationCommand, Guid>
{
    private readonly IApplicationUserNotificationDomainRepository _applicationUserNotificationRepository;

    public AddUserNotificationCommandHandler(IApplicationUserNotificationDomainRepository applicationUserNotificationRepository)
    {
        _applicationUserNotificationRepository = applicationUserNotificationRepository;
    }

    public ValueTask<Guid> Handle(AddUserNotificationCommand command, CancellationToken cancellationToken)
    {
        var userNotification = ApplicationUserNotification.Create(command.UserId, command.NotificationId);
        var userNotificationId = _applicationUserNotificationRepository.Add(userNotification);
        return ValueTask.FromResult(userNotificationId);
    }
}
public record AddUserNotificationCommand(Guid UserId, Guid NotificationId): ICommand<Guid>;