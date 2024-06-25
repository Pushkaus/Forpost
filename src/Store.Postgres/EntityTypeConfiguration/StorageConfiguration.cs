using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class StorageConfiguration: IEntityTypeConfiguration<Storage>
{
    public void Configure(EntityTypeBuilder<Storage> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Id).ValueGeneratedOnAdd();
        builder.HasOne(entity => entity.Employee)
            .WithMany(entity => entity.Storages)
            .HasForeignKey(entity => entity.ResponsibleId);
    }
}