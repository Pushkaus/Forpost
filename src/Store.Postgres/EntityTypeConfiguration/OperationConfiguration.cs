using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

public class OperationConfiguration : IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder.ConfigureBaseEntity();
        
        builder.Property(entity => entity.Name).HasMaxLength(DatabaseConstrains.MaxLenght);
        builder.Property(entity => entity.Description).HasMaxLength(DatabaseConstrains.MaxLenght);
    }
}