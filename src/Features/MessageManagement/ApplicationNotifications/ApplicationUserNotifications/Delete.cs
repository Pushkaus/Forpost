using Forpost.Domain.MessagesManagement.ApplicationNotifications;
using Mediator;

namespace Forpost.Features.MessageManagement.ApplicationNotifications.ApplicationUserNotifications;

internal sealed class DeleteUserNotificationByIdCommandHandler: ICommandHandler<DeleteUserNotificationByIdCommand>
{
    private readonly IApplicationUserNotificationDomainRepository _applicationUserNotificationRepository;

    public DeleteUserNotificationByIdCommandHandler(IApplicationUserNotificationDomainRepository applicationUserNotificationRepository)
    {
        _applicationUserNotificationRepository = applicationUserNotificationRepository;
    }

    public ValueTask<Unit> Handle(DeleteUserNotificationByIdCommand command, CancellationToken cancellationToken)
    {
        _applicationUserNotificationRepository.DeleteById(command.Id);
        return ValueTask.FromResult(Unit.Value);
    }
}
public record DeleteUserNotificationByIdCommand(Guid Id): ICommand;