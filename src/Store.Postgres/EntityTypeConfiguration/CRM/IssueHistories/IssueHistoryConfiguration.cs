using Forpost.Domain.Crm.IssueHistory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.CRM.IssueHistories;

internal sealed class IssueHistoryConfiguration: IEntityTypeConfiguration<IssueHistory>
{
    public void Configure(EntityTypeBuilder<IssueHistory> builder)
    {
        builder.ConfigureBaseEntity();
    }
}