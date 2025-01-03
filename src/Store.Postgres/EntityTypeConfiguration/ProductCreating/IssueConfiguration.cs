using Forpost.Domain.Catalogs.Employees;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.ProductCreating;

internal sealed class IssueConfiguration: IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.ConfigureBaseEntity();
        
        builder.HasOne<ManufacturingProcess>()
            .WithMany()
            .HasForeignKey(fk => fk.ManufacturingProcessId);
        
        builder.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(fk => fk.ExecutorId);
        
        builder.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(fk => fk.ResponsibleId);

        builder.Property(x => x.IssueStatus)
            .ConfigureSmartEnumerationAsEnum();
    }
}