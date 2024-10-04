using Forpost.Domain.CRM.IssueHistory;
using Forpost.Domain.ProductCreating.Issue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.ProductCreating;

internal sealed class IssueHistoryConfiguration: IEntityTypeConfiguration<IssueHistory>
{
    public void Configure(EntityTypeBuilder<IssueHistory> builder)
    {
        builder.ConfigureBaseEntity();
    }
}