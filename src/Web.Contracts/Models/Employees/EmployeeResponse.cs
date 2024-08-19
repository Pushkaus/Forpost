namespace Forpost.Web.Contracts.Models.Employees;

public class EmployeeResponse
{
    public Guid Id { get; set; }

    /// <summary>
    ///     Имя сотрудника
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    ///     Фамилия сотрудника
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    ///     Отчество сотрудника
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    ///     Должность сотрудника
    /// </summary>
    public string Post { get; set; }

    /// <summary>
    ///     Id на роль в приложении
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    ///     Почта сотрудника
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    ///     Номер телефона сотрудника
    /// </summary>
    public string PhoneNumber { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
}