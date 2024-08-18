using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

public class FileEntityConfiguration : IEntityTypeConfiguration<FileEntity>
{
    public void Configure(EntityTypeBuilder<FileEntity> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(entity => entity.FileName).HasMaxLength(DatabaseConstrains.MaxLenght);
        builder.Property(entity => entity.FilePath).HasMaxLength(DatabaseConstrains.MaxLenght);
        builder.Property(entity => entity.ContentType).HasMaxLength(DatabaseConstrains.MaxLenght);
    }
}