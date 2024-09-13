using Forpost.Domain.InvoiceManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.InvoiceManagment;

internal sealed class CompositionInvoiceConfiguration: IEntityTypeConfiguration<CompositionInvoice>
{
    public void Configure(EntityTypeBuilder<CompositionInvoice> builder)
    {
        builder.ConfigureBaseEntity();
    }
}