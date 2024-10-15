using Forpost.Domain.MessagesManagment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.MessagesManager;

internal sealed class NotificationForUsersConfiguration: IEntityTypeConfiguration<NotificationForUsers>
{
    public void Configure(EntityTypeBuilder<NotificationForUsers> builder)
    {
        builder.ConfigureBaseEntity();
    }
}