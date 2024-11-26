using Forpost.Domain.Catalogs.Contractors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.Catalogs;

internal sealed class ContactorConfiguration : IEntityTypeConfiguration<Contractor>
{
    public void Configure(EntityTypeBuilder<Contractor> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(entity => entity.Name)
            .HasMaxLength(DatabaseConstrains.MaxLength);
        
        builder.HasIndex(contractor => contractor.Name).IsUnique();

        builder.Property(x => x.ContractType)
            .ConfigureSmartEnumerationAsEnum();
    }
}