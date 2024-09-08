using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = Forpost.Domain.FileStorage.File;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class FileConfiguration : IEntityTypeConfiguration<File>
{
    public void Configure(EntityTypeBuilder<File> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(entity => entity.FileName).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.FilePath).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.ContentType).HasMaxLength(DatabaseConstrains.MaxLength);
    }
}