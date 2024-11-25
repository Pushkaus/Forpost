using Forpost.Domain.Catalogs.Contractors.ContractorRepresentatives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.Catalogs;

internal sealed class ContractorRepresantativeConfiguration: IEntityTypeConfiguration<ContractorRepresentative>
{
    public void Configure(EntityTypeBuilder<ContractorRepresentative> builder)
    {
        builder.ConfigureBaseEntity();
    }
}