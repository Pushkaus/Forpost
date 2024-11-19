using Forpost.Domain.CRM.InvoiceManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.CRM.InvoicesManagement;

internal sealed class CompositionInvoiceConfiguration: IEntityTypeConfiguration<CompositionInvoice>
{
    public void Configure(EntityTypeBuilder<CompositionInvoice> builder)
    {
        builder.ConfigureBaseEntity();
    }
}