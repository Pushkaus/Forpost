using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forpost.Store.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class DeleteStep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Steps_StepId",
                table: "Issues");

            migrationBuilder.DropTable(
                name: "TechCardSteps");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_Issues_StepId",
                table: "Issues");

            migrationBuilder.CreateTable(
                name: "TechCardOperations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TechCardId = table.Column<Guid>(type: "uuid", nullable: false),
                    OperationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechCardOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechCardOperations_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechCardOperations_TechCards_TechCardId",
                        column: x => x.TechCardId,
                        principalTable: "TechCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechCardOperations_OperationId",
                table: "TechCardOperations",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_TechCardOperations_TechCardId",
                table: "TechCardOperations",
                column: "TechCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechCardOperations");

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    OperationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechCardSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    StepId = table.Column<Guid>(type: "uuid", nullable: false),
                    TechCardId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechCardSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechCardSteps_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechCardSteps_TechCards_TechCardId",
                        column: x => x.TechCardId,
                        principalTable: "TechCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_StepId",
                table: "Issues",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_OperationId",
                table: "Steps",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_TechCardSteps_StepId",
                table: "TechCardSteps",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_TechCardSteps_TechCardId",
                table: "TechCardSteps",
                column: "TechCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Steps_StepId",
                table: "Issues",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
