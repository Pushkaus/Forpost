using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forpost.Store.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEntities2308AddStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ManufacturingProcesses",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ManufacturingProcesses");
        }
    }
}
