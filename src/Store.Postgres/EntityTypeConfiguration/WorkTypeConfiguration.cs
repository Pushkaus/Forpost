using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

public sealed class WorkTypeConfiguration: IEntityTypeConfiguration<WorkType>
{
    public void Configure(EntityTypeBuilder<WorkType> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Id).ValueGeneratedOnAdd();
        builder.HasMany(wt => wt.ProductWorks)
            .WithOne(pw => pw.WorkType)
            .HasForeignKey(pw => pw.WorkTypeId);
            
    }
}