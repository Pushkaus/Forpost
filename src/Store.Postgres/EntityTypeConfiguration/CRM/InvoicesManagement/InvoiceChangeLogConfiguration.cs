using Forpost.Domain.ChangeLogs;
using Forpost.Domain.CRM.InvoiceManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.CRM.InvoicesManagement;

internal sealed class InvoiceChangeLogConfiguration: IEntityTypeConfiguration<ChangeLog>
{
    public void Configure(EntityTypeBuilder<ChangeLog> builder)
    {
        builder.ConfigureBaseEntity();
    }
}