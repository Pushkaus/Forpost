using Forpost.Application.Contracts.MessageManagment;
using Mediator;

namespace Forpost.Features.MessageManagment;

internal sealed class GetAllQueryHandler : IQueryHandler<GetAllQuery, (IReadOnlyCollection<NotificationForUsersModel>
    Notifications, int TotalCount)>
{
    private readonly INotificationForUsersReadRepository _notificationForUsersReadRepository;

    public GetAllQueryHandler(INotificationForUsersReadRepository notificationForUsersReadRepository)
    {
        _notificationForUsersReadRepository = notificationForUsersReadRepository;
    }

    public async ValueTask<(IReadOnlyCollection<NotificationForUsersModel> Notifications, int TotalCount)> Handle(
        GetAllQuery query, CancellationToken cancellationToken)
    {
        var result = await _notificationForUsersReadRepository.GetAll(query.Skip, query.Limit, cancellationToken);
        return (result.Notifications, result.TotalCount);
    }
}

public record GetAllQuery(int Skip, int Limit)
    : IQuery<(IReadOnlyCollection<NotificationForUsersModel> Notifications, int TotalCount)>;