﻿using Forpost.Store.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Forpost.Store.Entities;

public sealed class Employee: IAuditableEntity
{
    public Employee() { }

    public Employee(Guid id, string firstName, string lastName, string? patronymic, string post, Guid roleId, string? email, string phoneNumber, string passwordHash, DateTimeOffset createdAt, Guid createdById, DateTimeOffset updatedAt, Guid updatedById, DateTimeOffset? deletedAt, Guid? deletedById, Role role)
    {
        Id = new Guid();
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Post = post;
        RoleId = roleId;
        Email = email;
        PhoneNumber = phoneNumber;
        PasswordHash = passwordHash;
        CreatedAt = createdAt;
        CreatedById = createdById;
        UpdatedAt = updatedAt;
        UpdatedById = updatedById;
        DeletedAt = deletedAt;
        DeletedById = deletedById;
    }

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
    /// <summary>
    /// Пароль сотрудника
    /// </summary>
    public string PasswordHash { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    public ICollection<Storage> Storages { get; set; }
    public Role Role { get; }
}
