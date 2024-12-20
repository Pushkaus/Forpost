using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forpost.Store.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class RefactoringTechCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_TechCards_TechCardId",
                table: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_Steps_TechCardId",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasure",
                table: "StorageProducts");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "TechCardId",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasure",
                table: "Steps");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasure",
                table: "StorageProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Steps",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "TechCardId",
                table: "Steps",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasure",
                table: "Steps",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Steps_TechCardId",
                table: "Steps",
                column: "TechCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_TechCards_TechCardId",
                table: "Steps",
                column: "TechCardId",
                principalTable: "TechCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
