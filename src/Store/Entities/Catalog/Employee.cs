using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities.Catalog;

public sealed class Employee : IAuditableEntity, IEntity
{
    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Фамилия сотрудника
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Отчество сотрудника
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Должность сотрудника
    /// </summary>
    public string Post { get; set; } = null!;

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
    public string PhoneNumber { get; set; } = null!;

    /// <summary>
    /// Пароль сотрудника
    /// </summary>
    public string PasswordHash { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    public Guid Id { get; set; }
}