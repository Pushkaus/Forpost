using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

public class ContragentConfiguration: IEntityTypeConfiguration<Contragent>
{
    public void Configure(EntityTypeBuilder<Contragent> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Id).ValueGeneratedOnAdd();
        builder.HasMany<Invoice>(entity => entity.Invoices)
            .WithOne(entity => entity.Contragent)
            .HasForeignKey(entity => entity.ContragentId);
    }
}