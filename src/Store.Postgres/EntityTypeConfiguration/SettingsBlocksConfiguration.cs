using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forpost.Store.Postgres.EntityTypeConfiguration
{
    internal class SettingsBlocksConfiguration : IEntityTypeConfiguration<SettingsBlock>
    {
        public void Configure(EntityTypeBuilder<SettingsBlock> builder)
        {
            builder.HasKey(e => e.SerialNumber).HasName("settings_blocks_pkey1");

            builder.ToTable("settings_blocks");

            builder.Property(e => e.SerialNumber)
                .ValueGeneratedNever()
                .HasColumnName("serial_number");
        }
    }
}
