using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.CRM.InvoiceManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.CRM.InvoicesManagment;

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
        
        builder.Property(x => x.InvoiceStatus)
            .ConfigureSmartEnumerationAsEnum();
        
        builder.Property(x => x.Priority)
            .ConfigureSmartEnumerationAsEnum();
        
        builder.Property(x => x.PaymentStatus)
            .ConfigureSmartEnumerationAsEnum();
    }
}