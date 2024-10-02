using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.MessageManagment;

public interface INotificationForUsersReadRepository: IApplicationReadRepository
{
    public Task<(IReadOnlyCollection<NotificationForUsersModel> Notifications, int TotalCount)> GetAll(int skip,
        int limit, CancellationToken cancellationToken);
}