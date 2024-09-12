using Forpost.Domain.Catalogs.Employees;
using Forpost.Domain.Catalogs.Storages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.StorageManagment;

internal sealed class StorageConfiguration : IEntityTypeConfiguration<Storage>
{
    public void Configure(EntityTypeBuilder<Storage> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(key => key.ResponsibleId);

        builder.Property(entity => entity.Name).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.Description).HasMaxLength(DatabaseConstrains.MaxLength);
    }
}