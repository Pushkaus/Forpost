using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Postgres;

public static class MigrationManager
{
    public static async Task MigrateData(ForpostContextPostgres context)
    {
        await GenerateFirstUser(context); 
        //await GenerateFirstTechCard(context);
    }

    public static async Task MigrateSchema(ForpostContextPostgres context)
    {
        await context.Database.MigrateAsync();
    }

    public static async Task GenerateFirstUser(ForpostContextPostgres context)
    {
        
        var userId = new Guid("15492e30-8df3-132f-9de6-3fcd91e38923");
        var roleId = new Guid("05492e30-8df3-432f-9de6-3fcd91e389f5");
        var createdAt = DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
   
        const string passwordHash = "AQAAAAIAAYagAAAAEGyBmwpFq9JfhWPbknKvvf2jNN6ix79jnbyMAAi87jI9/+rXaTqLCaL13m5D+FcNow==";

        var roleExists = await context.Roles.AnyAsync(r => r.Id == roleId);

        if (!roleExists)
        {
            var insertRoleSql = $@"
        INSERT INTO ""Roles"" (""Id"", ""Name"") 
        VALUES ('{roleId}', 'Admin');
    ";
            await context.Database.ExecuteSqlRawAsync(insertRoleSql);
        }

        var userExists = await context.Employees.AnyAsync(e => e.Id == userId);

        if (!userExists)
        {
            var insertEmployeeSql = $@"
        INSERT INTO ""Employees"" (""Id"", ""FirstName"", ""LastName"", ""Patronymic"", ""Post"", ""RoleId"",
                                   ""Email"", ""PhoneNumber"", ""PasswordHash"", ""CreatedAt"", ""CreatedById"",
                                   ""UpdatedAt"", ""UpdatedById"") 
        VALUES ('{userId}', 'test', 'test', NULL, 'Administrator', '{roleId}',
                'default@employee.com', '1234567890', '{passwordHash}', '{createdAt}', '{userId}', '{createdAt}', '{userId}');
    ";
            await context.Database.ExecuteSqlRawAsync(insertEmployeeSql);
        }
    }
    
    public static async Task GenerateFirstTechCard(ForpostContextPostgres context)
    {
        var dateTimeNow = "2024-08-22T12:45:47+00:00";
        var userId = "15492e30-8df3-132f-9de6-3fcd91e38923";
        
        var productId1 = "8731BFD3-F693-4577-B8DC-2F96AFF063ED";
        var productId2 = "AE3C94B5-77A1-4548-AC65-E158345448BD";
        var productId3 = "B88A2B64-2938-4AB6-AA6E-329DDAC9C53C";
        var productId4 = "8587D06C-DEB3-45BA-8A5B-98406F7A18CF";

        var techCardId = "9F44A641-B377-48A1-9988-E3CFCC653968";

        var techCardItemId1 = "45737F96-1C2C-47FB-A33F-79D8661D86A8";
        var techCardItemId2 = "59F0EE40-C8AB-499E-8FED-755EE43BC26D";
        var techCardItemId3 = "D19CED55-CCDC-421B-9A35-8531A300F2C0"; 

        var stepId1 = "01D5C487-335E-48FE-8BED-EF043030561C";
        var stepId2 = "29651264-C55D-4592-80DC-9A43653BD318";
        var stepId3 = "09A7123B-507B-4DE7-AF65-516E1CEA39C6";
        var stepId4 = "C2EF8CA2-4596-4AA8-A12A-7693468C349E";
        var stepId5 = "C5FD4CC4-13B4-4702-A977-5A33C6FD8792";
        var stepId6 = "02B59986-190D-4B5E-BF83-8D65F4F3BE9E";
        
        var techCardStepId1 = "169AB0EA-6856-45DE-8FA4-87C73EB68F6A";
        var techCardStepId2 = "8C7952A3-4CC1-4F32-BADF-36F462A8FCE3";
        var techCardStepId3 = "44477A97-C0BE-49AD-94A6-621371436ECC";
        var techCardStepId4 = "6F8D5891-89C3-4154-96D0-B79A09F4CF5A";
        var techCardStepId5 = "89C91CEB-2C35-4863-B4BF-0A8D81D018BC";
        var techCardStepId6 = "FCBAF3F4-5C8B-4D26-9795-54A155DE0039";
        
        var operationId1 = "F3CD3205-BC25-4EE1-BD79-CA424D73B5B5";
        var operationId2 = "9FD01142-B1CE-4A24-A416-C22F08111D36";
        var operationId3 = "6CFED48D-B6BE-48F1-ACA2-080FB0CE4B61";
        var operationId4 = "CEFE990F-A957-4274-B303-32386A8F1A48";
        var operationId5 = "48D37D39-B5A1-4F6B-9F74-AE0C49B05B14";
        var operationId6 = "0EF359D0-93D4-4818-A2E9-E6DBAB09DFB6";
        
        var insertProductsSql = $@"
        INSERT INTO ""Products""
            (""Id"", ""Name"", ""CategoryId"", ""CreatedAt"", ""CreatedById"",
             ""UpdatedAt"", ""UpdatedById"", ""DeletedAt"", ""DeletedById"")
        VALUES
            ('{productId1}', 'БПС-3000-220/220в-15А-23', null, '{dateTimeNow}', '{userId}',
             '{dateTimeNow}', '{userId}', null, null),
            ('{productId2}', 'Плата диодов FOUT5000_220JYPv3', null, '{dateTimeNow}', '{userId}',
             '{dateTimeNow}', '{userId}', null, null),
            ('{productId3}', 'Плата ключей БПС3000.14.1ф.ПТ-v1', null, '{dateTimeNow}', '{userId}',
             '{dateTimeNow}', '{userId}', null, null),
            ('{productId4}', 'Радиатор БПС5000.23', null, '{dateTimeNow}', '{userId}',
             '{dateTimeNow}', '{userId}', null, null)
        ";
        var insertTechCardSql = $@"
        INSERT INTO ""TechCards"" (""Id"", ""Number"", ""Description"", ""ProductId"", ""CreatedById"")
        VALUES
            ('{techCardId}', 'ТК-001', null,
             '{productId1}', '{userId}')
        ";
        var insertTechCardItemsSql = $@"
        INSERT INTO ""TechCardItems"" (""Id"", ""TechCardId"", ""ProductId"", ""Quantity"")
        VALUES
            ('{techCardItemId1}', '{techCardId}',
             '{productId2}', 3),
            ('{techCardItemId2}', '{techCardId}',
             '{productId3}', 1),
            ('{techCardItemId3}', '{techCardId}',
             '{productId4}', 1)
        ";
        var insertOperationSql = $@"
        INSERT INTO ""Operations"" (""Id"", ""Name"", ""Description"")
            VALUES (
                    '{operationId1}', 'Набор', null),
                ({operationId2}, 'Сборка', null),
                ({operationId3}, 'Настройка', null),
                ({operationId4}, 'Прогон', null),
                ({operationId5}, 'Упаковка', null),
                ({operationId6}, 'Отгрузка', null)
            )";
        var insertStepsSql = $@"
        INSERT INTO ""Steps"" (""Id"", ""TechCardId"", ""OperationId"", ""Description"", ""Duration"", ""Cost"", ""UnitOfMeassure"")
        VALUES (
            '{stepId1}',       -- Id
            '{techCardId}',   -- TechCardId
            '{operationId1}',  -- OperationId
            'Набор компонентов для разработки', -- Description
            '01:30:00',       -- Duration
            400.00,           -- Cost
            1                 -- UnitOfMeassure (пример значения)
        ),
            (
            '{stepId2}',       -- Id
            '{techCardId}',   -- TechCardId
            '{operationId2}',  -- OperationId
             null, -- Description
            '03:30:00',       -- Duration
            780.00,           -- Cost
            1                 -- UnitOfMeassure (пример значения)
        ),
            (
            '{stepId3}',       -- Id
            '{techCardId}',   -- TechCardId
            '{operationId3}',  -- OperationId
             null, -- Description
            '03:05:00',       -- Duration
            330.00,           -- Cost
            1                 -- UnitOfMeassure (пример значения)
        ),
            (
            '{stepId4}',       -- Id
            '{techCardId}',   -- TechCardId
            '{operationId4}',  -- OperationId
             null, -- Description
            '00:30:00',       -- Duration
            1850.00,           -- Cost
            1                 -- UnitOfMeassure (пример значения)
        ),
            (
            '{stepId5}',       -- Id
            '{techCardId}',   -- TechCardId
            '{operationId5}',  -- OperationId
             null, -- Description
            '01:10:00',       -- Duration
            620.00,           -- Cost
            1                 -- UnitOfMeassure (пример значения)
        ),
            (
            '{stepId6}',       -- Id
            '{techCardId}',   -- TechCardId
            '{operationId6}',  -- OperationId
             null, -- Description
            '02:38:00',       -- Duration
            563.00,           -- Cost
            1                 -- UnitOfMeassure (пример значения)
        )";
        var insertTechCardStepsSql = $@"
        INSERT INTO ""TechCardSteps"" (""Id"", ""TechCardId"", ""StepId"", ""Number"")
        VALUES
            ('{techCardStepId1}', '{techCardId}', '{stepId1}', 1),
            ('{techCardStepId2}', '{techCardId}', '{stepId2}', 2),
            ('{techCardStepId3}', '{techCardId}', '{stepId3}', 3),
            ('{techCardStepId4}', '{techCardId}', '{stepId4}', 4),
            ('{techCardStepId5}', '{techCardId}', '{stepId5}', 5),
            ('{techCardStepId6}', '{techCardId}', '{stepId6}', 6)
            ";
        await context.Database.ExecuteSqlRawAsync(insertProductsSql);
        await context.Database.ExecuteSqlRawAsync(insertTechCardSql);
        await context.Database.ExecuteSqlRawAsync(insertTechCardItemsSql);
        await context.Database.ExecuteSqlRawAsync(insertOperationSql);
        await context.Database.ExecuteSqlRawAsync(insertStepsSql);
        await context.Database.ExecuteSqlRawAsync(insertTechCardStepsSql);

    }
}