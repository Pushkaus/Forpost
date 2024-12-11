using Forpost.Common.Utils;
using Forpost.Domain.MessagesManagement;
using Mediator;

namespace Forpost.Features.MessageManagement;

internal sealed class PublishCommandHandler : ICommandHandler<PublishCommand>
{
    private readonly INotificationForUsersDomainRepository _notificationRepository;
    private readonly IIdentityProvider _identityProvider;

    public PublishCommandHandler(INotificationForUsersDomainRepository notificationRepository,
        IIdentityProvider identityProvider)
    {
        _notificationRepository = notificationRepository;
        _identityProvider = identityProvider;
    }

    public async ValueTask<Unit> Handle(PublishCommand command, CancellationToken cancellationToken)
    {
        var notification = NotificationForUsers.Publish(command.Message);
        var userId = _identityProvider.GetUserId();
        if (userId == null) throw new UnauthorizedAccessException("Вы должны быть авторизованы");
        _notificationRepository.Add(notification);
        return Unit.Value;
    }
}

public record PublishCommand(string Message) : ICommand;