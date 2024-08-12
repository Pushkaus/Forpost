using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

public class IssueConfiguration: IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.ConfigureBaseEntity();
        
        builder.HasOne<Operation>()
            .WithOne()
            .HasForeignKey<Issue>(entity => entity.OperationId);

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(entity => entity.ProductId);
    }
}