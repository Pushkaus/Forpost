using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forpost.Store.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedProduct_ManufacturingProcess_ManufacturingProcessId",
                table: "CompletedProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedProduct_Products_ProductId",
                table: "CompletedProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Contragents_ContragentId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingProcess_TechCards_TechnologicalCardId",
                table: "ManufacturingProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_Step_Operations_OperationId",
                table: "Step");

            migrationBuilder.DropForeignKey(
                name: "FK_Step_TechCards_TechCardId",
                table: "Step");

            migrationBuilder.DropForeignKey(
                name: "FK_TechCardItem_Products_ProductId",
                table: "TechCardItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TechCardItem_TechCards_TechCardId",
                table: "TechCardItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TechCardStep_Step_StepId",
                table: "TechCardStep");

            migrationBuilder.DropForeignKey(
                name: "FK_TechCardStep_TechCards_TechCardId",
                table: "TechCardStep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechCardStep",
                table: "TechCardStep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechCardItem",
                table: "TechCardItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Step",
                table: "Step");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDevelopment",
                table: "ProductDevelopment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManufacturingProcess",
                table: "ManufacturingProcess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contragents",
                table: "Contragents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompletedProduct",
                table: "CompletedProduct");

            migrationBuilder.RenameTable(
                name: "TechCardStep",
                newName: "TechCardSteps");

            migrationBuilder.RenameTable(
                name: "TechCardItem",
                newName: "TechCardItems");

            migrationBuilder.RenameTable(
                name: "Step",
                newName: "Steps");

            migrationBuilder.RenameTable(
                name: "ProductDevelopment",
                newName: "ProductDevelopments");

            migrationBuilder.RenameTable(
                name: "ManufacturingProcess",
                newName: "ManufacturingProcesses");

            migrationBuilder.RenameTable(
                name: "Contragents",
                newName: "Contractors");

            migrationBuilder.RenameTable(
                name: "CompletedProduct",
                newName: "CompletedProducts");

            migrationBuilder.RenameIndex(
                name: "IX_TechCardStep_TechCardId",
                table: "TechCardSteps",
                newName: "IX_TechCardSteps_TechCardId");

            migrationBuilder.RenameIndex(
                name: "IX_TechCardStep_StepId",
                table: "TechCardSteps",
                newName: "IX_TechCardSteps_StepId");

            migrationBuilder.RenameIndex(
                name: "IX_TechCardItem_TechCardId",
                table: "TechCardItems",
                newName: "IX_TechCardItems_TechCardId");

            migrationBuilder.RenameIndex(
                name: "IX_TechCardItem_ProductId",
                table: "TechCardItems",
                newName: "IX_TechCardItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Step_TechCardId",
                table: "Steps",
                newName: "IX_Steps_TechCardId");

            migrationBuilder.RenameIndex(
                name: "IX_Step_OperationId",
                table: "Steps",
                newName: "IX_Steps_OperationId");

            migrationBuilder.RenameIndex(
                name: "IX_ManufacturingProcess_TechnologicalCardId",
                table: "ManufacturingProcesses",
                newName: "IX_ManufacturingProcesses_TechnologicalCardId");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedProduct_ProductId",
                table: "CompletedProducts",
                newName: "IX_CompletedProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedProduct_ManufacturingProcessId",
                table: "CompletedProducts",
                newName: "IX_CompletedProducts_ManufacturingProcessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechCardSteps",
                table: "TechCardSteps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechCardItems",
                table: "TechCardItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Steps",
                table: "Steps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDevelopments",
                table: "ProductDevelopments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManufacturingProcesses",
                table: "ManufacturingProcesses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contractors",
                table: "Contractors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompletedProducts",
                table: "CompletedProducts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ManufacturingProcessId = table.Column<Guid>(type: "uuid", nullable: false),
                    StepId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExecutorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResponsibleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CurrentQuantity = table.Column<int>(type: "integer", nullable: false),
                    IssueStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    StartTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedProducts_ManufacturingProcesses_ManufacturingProce~",
                table: "CompletedProducts",
                column: "ManufacturingProcessId",
                principalTable: "ManufacturingProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedProducts_Products_ProductId",
                table: "CompletedProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Contractors_ContragentId",
                table: "Invoices",
                column: "ContragentId",
                principalTable: "Contractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingProcesses_TechCards_TechnologicalCardId",
                table: "ManufacturingProcesses",
                column: "TechnologicalCardId",
                principalTable: "TechCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Operations_OperationId",
                table: "Steps",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_TechCards_TechCardId",
                table: "Steps",
                column: "TechCardId",
                principalTable: "TechCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechCardItems_Products_ProductId",
                table: "TechCardItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechCardItems_TechCards_TechCardId",
                table: "TechCardItems",
                column: "TechCardId",
                principalTable: "TechCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechCardSteps_Steps_StepId",
                table: "TechCardSteps",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechCardSteps_TechCards_TechCardId",
                table: "TechCardSteps",
                column: "TechCardId",
                principalTable: "TechCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedProducts_ManufacturingProcesses_ManufacturingProce~",
                table: "CompletedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedProducts_Products_ProductId",
                table: "CompletedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Contractors_ContragentId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingProcesses_TechCards_TechnologicalCardId",
                table: "ManufacturingProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Operations_OperationId",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_TechCards_TechCardId",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_TechCardItems_Products_ProductId",
                table: "TechCardItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TechCardItems_TechCards_TechCardId",
                table: "TechCardItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TechCardSteps_Steps_StepId",
                table: "TechCardSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_TechCardSteps_TechCards_TechCardId",
                table: "TechCardSteps");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechCardSteps",
                table: "TechCardSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechCardItems",
                table: "TechCardItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Steps",
                table: "Steps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDevelopments",
                table: "ProductDevelopments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManufacturingProcesses",
                table: "ManufacturingProcesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contractors",
                table: "Contractors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompletedProducts",
                table: "CompletedProducts");

            migrationBuilder.RenameTable(
                name: "TechCardSteps",
                newName: "TechCardStep");

            migrationBuilder.RenameTable(
                name: "TechCardItems",
                newName: "TechCardItem");

            migrationBuilder.RenameTable(
                name: "Steps",
                newName: "Step");

            migrationBuilder.RenameTable(
                name: "ProductDevelopments",
                newName: "ProductDevelopment");

            migrationBuilder.RenameTable(
                name: "ManufacturingProcesses",
                newName: "ManufacturingProcess");

            migrationBuilder.RenameTable(
                name: "Contractors",
                newName: "Contragents");

            migrationBuilder.RenameTable(
                name: "CompletedProducts",
                newName: "CompletedProduct");

            migrationBuilder.RenameIndex(
                name: "IX_TechCardSteps_TechCardId",
                table: "TechCardStep",
                newName: "IX_TechCardStep_TechCardId");

            migrationBuilder.RenameIndex(
                name: "IX_TechCardSteps_StepId",
                table: "TechCardStep",
                newName: "IX_TechCardStep_StepId");

            migrationBuilder.RenameIndex(
                name: "IX_TechCardItems_TechCardId",
                table: "TechCardItem",
                newName: "IX_TechCardItem_TechCardId");

            migrationBuilder.RenameIndex(
                name: "IX_TechCardItems_ProductId",
                table: "TechCardItem",
                newName: "IX_TechCardItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Steps_TechCardId",
                table: "Step",
                newName: "IX_Step_TechCardId");

            migrationBuilder.RenameIndex(
                name: "IX_Steps_OperationId",
                table: "Step",
                newName: "IX_Step_OperationId");

            migrationBuilder.RenameIndex(
                name: "IX_ManufacturingProcesses_TechnologicalCardId",
                table: "ManufacturingProcess",
                newName: "IX_ManufacturingProcess_TechnologicalCardId");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedProducts_ProductId",
                table: "CompletedProduct",
                newName: "IX_CompletedProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedProducts_ManufacturingProcessId",
                table: "CompletedProduct",
                newName: "IX_CompletedProduct_ManufacturingProcessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechCardStep",
                table: "TechCardStep",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechCardItem",
                table: "TechCardItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Step",
                table: "Step",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDevelopment",
                table: "ProductDevelopment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManufacturingProcess",
                table: "ManufacturingProcess",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contragents",
                table: "Contragents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompletedProduct",
                table: "CompletedProduct",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Contragents_ContragentId",
                table: "Invoices",
                column: "ContragentId",
                principalTable: "Contragents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingProcess_TechCards_TechnologicalCardId",
                table: "ManufacturingProcess",
                column: "TechnologicalCardId",
                principalTable: "TechCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Step_Operations_OperationId",
                table: "Step",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Step_TechCards_TechCardId",
                table: "Step",
                column: "TechCardId",
                principalTable: "TechCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechCardItem_Products_ProductId",
                table: "TechCardItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechCardItem_TechCards_TechCardId",
                table: "TechCardItem",
                column: "TechCardId",
                principalTable: "TechCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechCardStep_Step_StepId",
                table: "TechCardStep",
                column: "StepId",
                principalTable: "Step",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechCardStep_TechCards_TechCardId",
                table: "TechCardStep",
                column: "TechCardId",
                principalTable: "TechCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
