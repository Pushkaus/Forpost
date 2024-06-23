using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class AssemblyConfiguration: IEntityTypeConfiguration<Assembly>
{
    public void Configure(EntityTypeBuilder<Assembly> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.HasOne(entity => entity.Storage)    // Каждое сборочное изделие имеет один Storage
            .WithMany(storage => storage.Assemblies) // Один Storage может содержать много сборочных изделий
            .HasForeignKey(entity => entity.StorageId); // Внешний ключ в Assembly
    }
}