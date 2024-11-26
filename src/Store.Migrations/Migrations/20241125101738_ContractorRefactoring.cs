using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forpost.Store.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class ContractorRefactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Contractors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ContractType",
                table: "Contractors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Contractors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Contractors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountLevel",
                table: "Contractors",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "INN",
                table: "Contractors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LogisticInfo",
                table: "Contractors",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContractorRepresentatives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContractorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Post = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorRepresentatives", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractorRepresentatives");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "ContractType",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "DiscountLevel",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "INN",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "LogisticInfo",
                table: "Contractors");
        }
    }
}
