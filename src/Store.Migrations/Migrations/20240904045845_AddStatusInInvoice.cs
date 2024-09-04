using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forpost.Store.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusInInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Contractors_ContragentId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "ContragentId",
                table: "Invoices",
                newName: "ContractorId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_ContragentId",
                table: "Invoices",
                newName: "IX_Invoices_ContractorId");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaymentPercentage",
                table: "Invoices",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Invoices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_Name",
                table: "Contractors",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Contractors_ContractorId",
                table: "Invoices",
                column: "ContractorId",
                principalTable: "Contractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Contractors_ContractorId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Contractors_Name",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "ContractorId",
                table: "Invoices",
                newName: "ContragentId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_ContractorId",
                table: "Invoices",
                newName: "IX_Invoices_ContragentId");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentPercentage",
                table: "Invoices",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Contractors_ContragentId",
                table: "Invoices",
                column: "ContragentId",
                principalTable: "Contractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
