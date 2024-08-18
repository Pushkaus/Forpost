using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class StorageConfiguration : IEntityTypeConfiguration<Storage>
{
    public void Configure(EntityTypeBuilder<Storage> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<Employee>()
            .WithOne()
            .HasForeignKey<Storage>(key => key.ResponsibleId);
        
        builder.Property(entity => entity.Name).HasMaxLength(DatabaseConstrains.MaxLenght);
        builder.Property(entity => entity.Description).HasMaxLength(DatabaseConstrains.MaxLenght);
    }
}