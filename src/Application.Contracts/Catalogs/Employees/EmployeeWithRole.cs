namespace Forpost.Application.Contracts.Catalogs.Employees;

public sealed record EmployeeWithRoleModel
{
    public Guid Id { get; set; }

    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Фамилия сотрудника
    /// </summary>
    public string LastName { get; set; } = default!;

    /// <summary>
    /// Отчество сотрудника
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Должность сотрудника
    /// </summary>
    public string Post { get; set; } = default!;

    /// <summary>
    /// Роль сотрудника
    /// </summary>
    public string Role { get; set; } = default!;

    public Guid RoleId { get; set; } 

    /// <summary>
    /// Почта сотрудника
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Номер телефона сотрудника
    /// </summary>
    public string PhoneNumber { get; set; } = default!;
    
}