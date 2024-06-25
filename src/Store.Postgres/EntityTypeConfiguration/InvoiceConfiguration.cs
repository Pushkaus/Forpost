using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal class InvoiceConfiguration: IEntityTypeConfiguration<Invoice>
{
   public void Configure(EntityTypeBuilder<Invoice> builder)
   {
      builder.HasKey(entity => entity.Id);
      builder.Property(entity => entity.Id).ValueGeneratedOnAdd();
      builder.HasMany(entity => entity.InvoiceProducts)
         .WithOne(entity => entity.Invoice)
         .HasForeignKey(entity => entity.InvoiceId);
   }
}