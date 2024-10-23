using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forpost.Store.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductBarcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductBarcodes");

            migrationBuilder.AddColumn<string>(
                name: "Nomenclature",
                table: "ProductBarcodes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nomenclature",
                table: "ProductBarcodes");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductBarcodes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
