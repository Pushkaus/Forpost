namespace Forpost.Business.Models.Accounts;

public sealed class EmployeeWithRoleModel
{
    public Guid Id { get; set; }
        
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
    /// Роль сотрудника
    /// </summary>
    public string Role { get; set; }
        
    /// <summary>
    /// Почта сотрудника
    /// </summary>
    public string? Email { get; set; }
        
    /// <summary>
    /// Номер телефона сотрудника
    /// </summary>
    public string PhoneNumber { get; set; }
        
    /// <summary>
    /// Пароль сотрудника
    /// </summary>
    public string PasswordHash { get; set; }
}