using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal sealed class FileEntityConfiguration : IEntityTypeConfiguration<FileEntity>
{
    public void Configure(EntityTypeBuilder<FileEntity> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(entity => entity.FileName).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.FilePath).HasMaxLength(DatabaseConstrains.MaxLength);
        builder.Property(entity => entity.ContentType).HasMaxLength(DatabaseConstrains.MaxLength);
    }
}