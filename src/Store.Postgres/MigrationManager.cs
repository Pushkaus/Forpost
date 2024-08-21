using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Postgres;

public static class MigrationManager
{
    public static async Task MigrateData(ForpostContextPostgres context)
    {
        await GenerateFirstUser(context);
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
   
        const string passwordHash = "AQAAAAIAAYagAAAAEFfWkQvwd4hja19jKrd1rYqLWLwCv1cjfJKTXrOfI7wVn3n5GjQPaN7SGsKDJVD06w";

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
}