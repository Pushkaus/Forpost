using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Postgres.EntityTypeConfiguration
{
    internal class InvoiceIssuedConfiguration : IEntityTypeConfiguration<InvoiceIssued>
    {
        public void Configure(EntityTypeBuilder<InvoiceIssued> builder)
        {
            builder.Property(x => x.Id)
                            .ValueGeneratedOnAdd()
                            .IsRequired();

            builder.HasMany(i => i.Items)
                .WithOne(ii => ii.InvoiceIssued)
                .HasForeignKey(ii => ii.InvoiceIssuedId)
                .IsRequired();

        }
    }
}
