using Forpost.Domain.StorageManagment.EntryStorageHistories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.StorageManagment;

internal sealed class EntryStorageHistoryConfiguration: IEntityTypeConfiguration<EntryStorageHistory>
{
    public void Configure(EntityTypeBuilder<EntryStorageHistory> builder)
    {
        builder.ConfigureBaseEntity();
    }
}