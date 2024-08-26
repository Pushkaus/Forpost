using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forpost.Store.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class RenameEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedProducts_ManufacturingProcess_ManufacturingProcess~",
                table: "CompletedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedProducts_Products_ProductId",
                table: "CompletedProducts");

            migrationBuilder.DropTable(
                name: "TechCardItems");

            migrationBuilder.DropTable(
                name: "TechCardSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDevelopments",
                table: "ProductDevelopments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompletedProducts",
                table: "CompletedProducts");

            migrationBuilder.RenameTable(
                name: "ProductDevelopments",
                newName: "ProductDevelopment");

            migrationBuilder.RenameTable(
                name: "CompletedProducts",
                newName: "CompletedProduct");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedProducts_ProductId",
                table: "CompletedProduct",
                newName: "IX_CompletedProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedProducts_ManufacturingProcessId",
                table: "CompletedProduct",
                newName: "IX_CompletedProduct_ManufacturingProcessId");

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDevelopment",
                table: "ProductDevelopment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompletedProduct",
                table: "CompletedProduct",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TechCardItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TechCardId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechCardItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechCardItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechCardItem_TechCards_TechCardId",
                        column: x => x.TechCardId,
                        principalTable: "TechCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechCardStep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TechCardId = table.Column<Guid>(type: "uuid", nullable: false),
                    StepId = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechCardStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechCardStep_Step_StepId",
                        column: x => x.StepId,
                        principalTable: "Step",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechCardStep_TechCards_TechCardId",
                        column: x => x.TechCardId,
                        principalTable: "TechCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechCardItem_ProductId",
                table: "TechCardItem",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechCardItem_TechCardId",
                table: "TechCardItem",
                column: "TechCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechCardStep_StepId",
                table: "TechCardStep",
                column: "StepId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechCardStep_TechCardId",
                table: "TechCardStep",
                column: "TechCardId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedProduct_ManufacturingProcess_ManufacturingProcessId",
                table: "CompletedProduct",
                column: "ManufacturingProcessId",
                principalTable: "ManufacturingProcess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedProduct_Products_ProductId",
                table: "CompletedProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedProduct_ManufacturingProcess_ManufacturingProcessId",
                table: "CompletedProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedProduct_Products_ProductId",
                table: "CompletedProduct");

            migrationBuilder.DropTable(
                name: "TechCardItem");

            migrationBuilder.DropTable(
                name: "TechCardStep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDevelopment",
                table: "ProductDevelopment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompletedProduct",
                table: "CompletedProduct");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "ProductDevelopment",
                newName: "ProductDevelopments");

            migrationBuilder.RenameTable(
                name: "CompletedProduct",
                newName: "CompletedProducts");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedProduct_ProductId",
                table: "CompletedProducts",
                newName: "IX_CompletedProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedProduct_ManufacturingProcessId",
                table: "CompletedProducts",
                newName: "IX_CompletedProducts_ManufacturingProcessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDevelopments",
                table: "ProductDevelopments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompletedProducts",
                table: "CompletedProducts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TechCardItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    TechCardId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechCardItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechCardItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechCardItems_TechCards_TechCardId",
                        column: x => x.TechCardId,
                        principalTable: "TechCards",
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
                        name: "FK_TechCardSteps_Step_StepId",
                        column: x => x.StepId,
                        principalTable: "Step",
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
                name: "IX_TechCardSteps_StepId",
                table: "TechCardSteps",
                column: "StepId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechCardSteps_TechCardId",
                table: "TechCardSteps",
                column: "TechCardId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedProducts_ManufacturingProcess_ManufacturingProcess~",
                table: "CompletedProducts",
                column: "ManufacturingProcessId",
                principalTable: "ManufacturingProcess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
