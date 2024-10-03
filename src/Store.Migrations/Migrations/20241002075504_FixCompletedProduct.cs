using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forpost.Store.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class FixCompletedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompletedProducts_ManufacturingProcessId",
                table: "CompletedProducts");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedProducts_ManufacturingProcessId",
                table: "CompletedProducts",
                column: "ManufacturingProcessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompletedProducts_ManufacturingProcessId",
                table: "CompletedProducts");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedProducts_ManufacturingProcessId",
                table: "CompletedProducts",
                column: "ManufacturingProcessId",
                unique: true);
        }
    }
}
