using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Crm.InvoiceManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.CRM.InvoicesManagement;

internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ConfigureBaseEntity();
        
        builder.HasIndex(x => x.Number).IsUnique();

        builder.HasOne<Contractor>()
            .WithMany()
            .HasForeignKey(key => key.ContractorId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(entity => entity.Number).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.Description).HasMaxLength(DatabaseConstrains.MaxLength);
        
        builder.Property(x => x.InvoiceStatus)
            .ConfigureSmartEnumerationAsEnum();
        
        builder.Property(x => x.Priority)
            .ConfigureSmartEnumerationAsEnum();
        
        builder.Property(x => x.PaymentStatus)
            .ConfigureSmartEnumerationAsEnum();
    }
}