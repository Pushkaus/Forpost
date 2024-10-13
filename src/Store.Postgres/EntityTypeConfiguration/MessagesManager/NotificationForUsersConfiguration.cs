using Forpost.Domain.MessageManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.MessageManager;

internal sealed class NotificationForUsersConfiguration: IEntityTypeConfiguration<NotificationForUsers>
{
    public void Configure(EntityTypeBuilder<NotificationForUsers> builder)
    {
        builder.ConfigureBaseEntity();
    }
}