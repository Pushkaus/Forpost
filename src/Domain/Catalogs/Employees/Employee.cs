using Forpost.Common.EntityTemplates;

namespace Forpost.Domain.Catalogs.Employees;

public sealed class Employee : DomainAuditableEntity
{
    private Employee(string firstName, string lastName, string? patronymic, string post, Guid roleId, string? email,
        string phoneNumber, string passwordHash)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Post = post;
        RoleId = roleId;
        Email = email;
        PhoneNumber = phoneNumber;
        PasswordHash = passwordHash;
    }

    public static Employee Register(string firstName,
        string lastName,
        string post,
        Guid roleId,
        string passwordHash,
        string phoneNumber,
        string? patronymic = null,
        string? email = null)
    {
        return new Employee(firstName, lastName, patronymic, post, roleId, email, phoneNumber, passwordHash);
    }

    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Фамилия сотрудника
    /// </summary>
    public string LastName { get; private set; }

    /// <summary>
    /// Отчество сотрудника
    /// </summary>
    public string? Patronymic { get; private set; }

    /// <summary>
    /// Должность сотрудника
    /// </summary>
    public string Post { get; private set; }

    /// <summary>
    /// Id на роль в приложении
    /// </summary>
    public Guid RoleId { get; private set; }

    /// <summary>
    /// Почта сотрудника
    /// </summary>
    public string? Email { get; private set; }

    /// <summary>
    /// Номер телефона сотрудника
    /// </summary>
    public string PhoneNumber { get; private set; }

    /// <summary>
    /// Пароль сотрудника
    /// </summary>
    public string PasswordHash { get; private set; }
}