using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forpost.Store.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TechCardSteps_StepId",
                table: "TechCardSteps");

            migrationBuilder.DropIndex(
                name: "IX_TechCardSteps_TechCardId",
                table: "TechCardSteps");

            migrationBuilder.DropIndex(
                name: "IX_TechCardItems_ProductId",
                table: "TechCardItems");

            migrationBuilder.DropIndex(
                name: "IX_TechCardItems_TechCardId",
                table: "TechCardItems");

            migrationBuilder.DropIndex(
                name: "IX_Steps_OperationId",
                table: "Steps");

            migrationBuilder.CreateIndex(
                name: "IX_TechCardSteps_StepId",
                table: "TechCardSteps",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_TechCardSteps_TechCardId",
                table: "TechCardSteps",
                column: "TechCardId");

            migrationBuilder.CreateIndex(
                name: "IX_TechCardItems_ProductId",
                table: "TechCardItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TechCardItems_TechCardId",
                table: "TechCardItems",
                column: "TechCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_OperationId",
                table: "Steps",
                column: "OperationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TechCardSteps_StepId",
                table: "TechCardSteps");

            migrationBuilder.DropIndex(
                name: "IX_TechCardSteps_TechCardId",
                table: "TechCardSteps");

            migrationBuilder.DropIndex(
                name: "IX_TechCardItems_ProductId",
                table: "TechCardItems");

            migrationBuilder.DropIndex(
                name: "IX_TechCardItems_TechCardId",
                table: "TechCardItems");

            migrationBuilder.DropIndex(
                name: "IX_Steps_OperationId",
                table: "Steps");

            migrationBuilder.CreateIndex(
                name: "IX_TechCardSteps_StepId",
                table: "TechCardSteps",
                column: "StepId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechCardSteps_TechCardId",
                table: "TechCardSteps",
                column: "TechCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechCardItems_ProductId",
                table: "TechCardItems",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechCardItems_TechCardId",
                table: "TechCardItems",
                column: "TechCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Steps_OperationId",
                table: "Steps",
                column: "OperationId",
                unique: true);
        }
    }
}
