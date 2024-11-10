namespace Forpost.Web.Contracts.Catalogs.Employees;

public sealed class EmployeeRequest
{
    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия сотрудника
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Отчество сотрудника
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Должность сотрудника
    /// </summary>
    public string Post { get; set; }
    
    /// <summary>
    /// Id на роль в приложении
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    /// Почта сотрудника
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Номер телефона сотрудника
    /// </summary>
    public string PhoneNumber { get; set; }
    
    public string PasswordHash { get; set; }
}