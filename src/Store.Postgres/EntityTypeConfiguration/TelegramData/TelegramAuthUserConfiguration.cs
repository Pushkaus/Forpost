using Forpost.Domain.TelegramData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration.TelegramData;

internal sealed class TelegramAuthUserConfiguration: IEntityTypeConfiguration<TelegramAuthUser>
{
    public void Configure(EntityTypeBuilder<TelegramAuthUser> builder)
    {
        builder.ConfigureBaseEntity();
    }
}