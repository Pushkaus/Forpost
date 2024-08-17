using Forpost.Store.Entities;
using Forpost.Store.Entities.ProductCreating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

public class IssueConfiguration: IEntityTypeConfiguration<Step>
{
    public void Configure(EntityTypeBuilder<Step> builder)
    {
        builder.ConfigureBaseEntity();
        
        
            
        builder.HasOne<Operation>()
            .WithOne()
            .HasForeignKey<Step>(entity => entity.OperationId);

        
    }
}