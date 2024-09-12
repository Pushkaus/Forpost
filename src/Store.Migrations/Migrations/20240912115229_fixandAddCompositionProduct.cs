using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forpost.Store.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class fixandAddCompositionProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedProducts_Products_ProductId",
                table: "CompletedProducts");

            migrationBuilder.DropIndex(
                name: "IX_Storages_ResponsibleId",
                table: "Storages");

            migrationBuilder.DropIndex(
                name: "IX_CompletedProducts_ProductId",
                table: "CompletedProducts");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "CompletedProducts");

            migrationBuilder.AddColumn<bool>(
                name: "ProductCompositionSettingFlag",
                table: "Issues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductDevelopmentId",
                table: "CompletedProducts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CompletedProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CompositionInvoice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompletedProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompositionInvoice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompositionProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompositionProducts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Storages_ResponsibleId",
                table: "Storages",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedProducts_ProductDevelopmentId",
                table: "CompletedProducts",
                column: "ProductDevelopmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedProducts_ProductDevelopments_ProductDevelopmentId",
                table: "CompletedProducts",
                column: "ProductDevelopmentId",
                principalTable: "ProductDevelopments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedProducts_ProductDevelopments_ProductDevelopmentId",
                table: "CompletedProducts");

            migrationBuilder.DropTable(
                name: "CompositionInvoice");

            migrationBuilder.DropTable(
                name: "CompositionProducts");

            migrationBuilder.DropIndex(
                name: "IX_Storages_ResponsibleId",
                table: "Storages");

            migrationBuilder.DropIndex(
                name: "IX_CompletedProducts_ProductDevelopmentId",
                table: "CompletedProducts");

            migrationBuilder.DropColumn(
                name: "ProductCompositionSettingFlag",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ProductDevelopmentId",
                table: "CompletedProducts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CompletedProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceId",
                table: "CompletedProducts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Storages_ResponsibleId",
                table: "Storages",
                column: "ResponsibleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompletedProducts_ProductId",
                table: "CompletedProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedProducts_Products_ProductId",
                table: "CompletedProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
