using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forpost.Store.Postgres.EntityTypeConfiguration
{
    internal class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.Property(x => x.Id)
             .ValueGeneratedOnAdd()
             .IsRequired();

            builder.Property(x => x.NameDevice)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.HasOne(ii => ii.InvoiceIssued)
                .WithMany(i => i.Items)
                .HasForeignKey(ii => ii.InvoiceIssuedId)
                .IsRequired(); builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
