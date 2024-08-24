using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class StorageConfiguration : IEntityTypeConfiguration<StorageEntity>
{
    public void Configure(EntityTypeBuilder<StorageEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<EmployeeEntity>()
            .WithOne()
            .HasForeignKey<StorageEntity>(key => key.ResponsibleId);
        
        builder.Property(entity => entity.Name).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.Description).HasMaxLength(DatabaseConstrains.MaxLength);
    }
}