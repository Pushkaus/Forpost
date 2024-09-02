using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.InvoiceManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<Contractor>()
            .WithMany()
            .HasForeignKey(key => key.ContractorId);

        builder.Property(entity => entity.Number).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.Description).HasMaxLength(DatabaseConstrains.MaxLength);
    }
}