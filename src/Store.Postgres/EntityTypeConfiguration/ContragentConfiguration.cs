using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration;

sealed public class ContragentConfiguration: IEntityTypeConfiguration<Contragent>
{
    public void Configure(EntityTypeBuilder<Contragent> builder)
    {
        builder.ConfigureBaseEntity();
    }
}
