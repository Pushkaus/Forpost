using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forpost.Store.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class FIXChangeLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PropertyNameOnClient",
                table: "ChangeLogs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyNameOnClient",
                table: "ChangeLogs");
        }
    }
}
