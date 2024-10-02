using AutoMapper;
using Forpost.Domain.MessageManager;
using Mediator;

namespace Forpost.Features.MessageManagment;

internal sealed class PublishCommandHandler: ICommandHandler<PublishCommand>
{
    private readonly INotificationForUsersDomainRepository _notificationRepository;

    public PublishCommandHandler(INotificationForUsersDomainRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async ValueTask<Unit> Handle(PublishCommand command, CancellationToken cancellationToken)
    {
        var notification = NotificationForUsers.Publish(command.Message);
        _notificationRepository.Add(notification);
        return Unit.Value;
    }
}
public record PublishCommand(string Message): ICommand;