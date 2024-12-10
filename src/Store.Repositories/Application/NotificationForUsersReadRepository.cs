using System.Linq.Dynamic.Core;
using Forpost.Application.Contracts.MessageManagement;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class NotificationForUsersReadRepository : INotificationForUsersReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public NotificationForUsersReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(IReadOnlyCollection<NotificationForUsersModel> Notifications, int TotalCount)> GetAll(int skip, int limit, CancellationToken cancellationToken)
    {
        var totalCount = await _dbContext.NotificationsForUsers
            .NotDeletedAt()
            .CountAsync(cancellationToken);


        var notifications = await _dbContext.NotificationsForUsers
            .NotDeletedAt()
            .Join(_dbContext.Employees,
                notification => notification.CreatedById,
                employee => employee.Id,
                (notification, employee) => new NotificationForUsersModel
                {
                    Id = notification.Id,
                    Message = notification.Message,
                    AuthorName = employee.FirstName + " " + employee.LastName,
                    CreatedAt = notification.CreatedAt,
                    CreatedById = notification.CreatedById,
                })
            .OrderByDescending(notification => notification.CreatedAt)
            .Skip(skip)
            .Take(limit)
            .ToListAsync(cancellationToken);
        return (notifications, totalCount);
    }

}