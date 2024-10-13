using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forpost.Store.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompositionInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompositionInvoice",
                table: "CompositionInvoice");

            migrationBuilder.RenameTable(
                name: "CompositionInvoice",
                newName: "CompositionInvoices");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "CompositionInvoices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CompositionInvoices",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "CompositionInvoices",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedById",
                table: "CompositionInvoices",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "CompositionInvoices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "CompositionInvoices",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompositionInvoices",
                table: "CompositionInvoices",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompositionInvoices",
                table: "CompositionInvoices");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CompositionInvoices");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CompositionInvoices");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "CompositionInvoices");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "CompositionInvoices");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CompositionInvoices");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "CompositionInvoices");

            migrationBuilder.RenameTable(
                name: "CompositionInvoices",
                newName: "CompositionInvoice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompositionInvoice",
                table: "CompositionInvoice",
                column: "Id");
        }
    }
}
