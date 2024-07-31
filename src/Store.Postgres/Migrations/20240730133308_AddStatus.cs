using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forpost.Store.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AddStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0fc1dcc2-c76e-487e-982a-e6f0acc3a4ed"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Issues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Invoices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "DeletedAt", "DeletedById", "Email", "FirstName", "LastName", "PasswordHash", "Patronymic", "PhoneNumber", "Post", "RoleId", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("04ebde8e-bd0a-4c6a-9eec-f2339e5a6914"), new DateTimeOffset(new DateTime(2024, 7, 30, 13, 33, 8, 213, DateTimeKind.Unspecified).AddTicks(3642), new TimeSpan(0, 0, 0, 0, 0)), new Guid("04ebde8e-bd0a-4c6a-9eec-f2339e5a6914"), null, null, "default@employee.com", "test", "test", "AQAAAAIAAYagAAAAEIzGnyIIuCDvtUtAK2dLpRAe+mZfyNM+r2NxHExPMqMWvEREaT3Y5IbpmJ2dq6vduw==", null, "1234567890", "Administrator", new Guid("05492e30-8df3-432f-9de6-3fcd91e389f5"), new DateTimeOffset(new DateTime(2024, 7, 30, 13, 33, 8, 213, DateTimeKind.Unspecified).AddTicks(3649), new TimeSpan(0, 0, 0, 0, 0)), new Guid("04ebde8e-bd0a-4c6a-9eec-f2339e5a6914") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("04ebde8e-bd0a-4c6a-9eec-f2339e5a6914"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Invoices");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "DeletedAt", "DeletedById", "Email", "FirstName", "LastName", "PasswordHash", "Patronymic", "PhoneNumber", "Post", "RoleId", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("0fc1dcc2-c76e-487e-982a-e6f0acc3a4ed"), new DateTimeOffset(new DateTime(2024, 7, 30, 13, 27, 24, 730, DateTimeKind.Unspecified).AddTicks(8980), new TimeSpan(0, 0, 0, 0, 0)), new Guid("0fc1dcc2-c76e-487e-982a-e6f0acc3a4ed"), null, null, "default@employee.com", "test", "test", "AQAAAAIAAYagAAAAEJU5xqBZACXc0dh+NuUuY9bqe8qfaWdT9kCXz7jkGxJ/jIaQS4mXppXVadasC89C4Q==", null, "1234567890", "Administrator", new Guid("05492e30-8df3-432f-9de6-3fcd91e389f5"), new DateTimeOffset(new DateTime(2024, 7, 30, 13, 27, 24, 730, DateTimeKind.Unspecified).AddTicks(8989), new TimeSpan(0, 0, 0, 0, 0)), new Guid("0fc1dcc2-c76e-487e-982a-e6f0acc3a4ed") });
        }
    }
}
