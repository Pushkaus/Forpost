using Forpost.Store.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;

namespace Forpost.Store.Postgres;


public static class StartMirgation
{
    public static async Task StartMigrationWithTestData(ForpostContextPostgres context)
    {
        try
        {
            Console.WriteLine("Старт миграции с начальными данными");
            await GenerateTestData(context);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при выполнении стартовой миграции: {e}");
            throw;
        }
    }
    public static async Task GenerateTestData(ForpostContextPostgres context)
    {
        var userId = new Guid("15492e30-8df3-132f-9de6-3fcd91e38923");
        var roleId = new Guid("05492e30-8df3-432f-9de6-3fcd91e389f5");
        var createdAt = DateTimeOffset.UtcNow;

        var passwordHash = "AQAAAAIAAYagAAAAEFfWkQvwd4hja19jKrd1rYqLWLwCv1cjfJKTXrOfI7wVn3n5GjQPaN7SGsKDJVD06w";

        var insertRoleSql = @"
                            INSERT INTO ""Roles"" (""Id"", ""Name"") 
                            VALUES (@roleId, 'Admin');
                            ";

        var insertEmployeeSql = @"
                INSERT INTO ""Employees""(""Id"", ""FirstName"", ""LastName"", ""Patronymic"", ""Post"", ""RoleId"",
                                           ""Email"", ""PhoneNumber"", ""PasswordHash"", ""CreatedAt"", ""CreatedById"",
                                          ""UpdatedAt"", ""UpdatedById"") 
                VALUES (@userId, 'test', 'test', NULL, 'Administrator', @roleId,
                       'default@employee.com', '1234567890', @passwordHash, @createdAt, @userId, @createdAt, @userId);
                                ";
        
        var parameters = new[]
        {
            new Npgsql.NpgsqlParameter("userId", userId),
            new Npgsql.NpgsqlParameter("roleId", roleId),
            new Npgsql.NpgsqlParameter("passwordHash", passwordHash),
            new Npgsql.NpgsqlParameter("createdAt", createdAt)
        };
        
        await context.Database.ExecuteSqlRawAsync(insertRoleSql, parameters[1]); // roleId
        await context.Database.ExecuteSqlRawAsync(insertEmployeeSql, parameters); // все параметры
    }
}