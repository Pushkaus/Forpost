using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forpost.Store.Migrations.DataMigrations
{
    /// <inheritdoc />
    public partial class FirstManufacturingProcess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //GenerateFirstManufacturingProcess(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
        public static void GenerateFirstManufacturingProcess(MigrationBuilder migrationBuilder)
        {
            var manufacturingProcessId = "E1E2F3A4-5678-90AB-CDEF-1234567890AB"; // Уникальный ID для ManufacturingProcess
        var techCardId = "9F44A641-B377-48A1-9988-E3CFCC653968"; // Предполагаемый существующий TechCardId
        var stepId1 = "01D5C487-335E-48FE-8BED-EF043030561C"; // Предполагаемый существующий StepId
        var userId = "15492e30-8df3-132f-9de6-3fcd91e38923"; // Предполагаемый существующий UserId (исполнитель и ответственный)
        var dateTimeNow = "2024-08-22T12:45:47+00:00"; // Время начала процесса

        // Вставка записи в ManufacturingProcesses
        var insertManufacturingProcessSql = $@"
            INSERT INTO ""ManufacturingProcesses"" (
                ""Id"",
                ""TechnologicalCardId"",
                ""BatchNumber"",
                ""CurrentQuantity"",
                ""TargetQuantity"",
                ""StartTime"",
                ""EndTime"",
                ""Status"",
                ""CreatedAt"",
                ""CreatedById"",                 
                ""UpdatedAt"",
                ""UpdatedById""
            ) VALUES (
                '{manufacturingProcessId}',
                '{techCardId}',
                'Batch_001',
                0,
                100,
                '{dateTimeNow}',
                NULL,
                0, -- Status: Pending
                '{dateTimeNow}',
                       '{userId}', -- ExecutorId
                '{dateTimeNow}',
                       '{userId}' -- ExecutorId
            );
        ";

        migrationBuilder.Sql(insertManufacturingProcessSql);

        // Вставка первой задачи Issue
        var issueId1 = "A1B2C3D4-E5F6-7890-ABCD-EF1234567890"; // Уникальный ID для первой задачи
        var issueNumber1 = 1;
        var insertIssueSql1 = $@"
            INSERT INTO ""Issues"" (
                ""Id"",
                ""ManufacturingProcessId"",
                ""StepId"",
                ""IssueNumber"",
                ""ExecutorId"",
                ""ResponsibleId"",
                ""Description"",
                ""CurrentQuantity"",
                ""IssueStatus"",
                ""ProductCompositionSettingFlag"",
                ""StartTime"",
                ""EndTime"",
                ""CreatedAt"",
                                    ""CreatedById"",
                ""UpdatedAt"",
                                    ""UpdatedById""
            ) VALUES (
                '{issueId1}',
                '{manufacturingProcessId}',
                '{stepId1}',
                {issueNumber1},
                '{userId}', -- ExecutorId
                '{userId}', -- ResponsibleId
                'Initial issue description',
                0,
                200, -- IssueStatus: Pending
                FALSE,
                NULL,
                NULL,
                '{dateTimeNow}',
                       '{userId}', -- ExecutorId
                '{dateTimeNow}',
                       '{userId}' -- ExecutorId
            );
        ";

        migrationBuilder.Sql(insertIssueSql1);
        }
    }
}
