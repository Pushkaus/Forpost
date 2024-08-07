using Forpost.Store.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Postgres.EntityTypeConfiguration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ConfigureBaseEntity();

            builder.HasData(new Role()
                {
                    Id = new Guid("05492e30-8df3-432f-9de6-3fcd91e389f5"),
                    Name = "Admin"
                }
            );
        }
    }
}