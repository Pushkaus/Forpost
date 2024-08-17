using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

internal class InvoiceConfiguration: IEntityTypeConfiguration<Invoice>
{
   public void Configure(EntityTypeBuilder<Invoice> builder)
   {
      builder.ConfigureBaseEntity();

      builder.HasOne<Contragent>()
         .WithMany()
         .HasForeignKey(key => key.ContragentId);
   }
}