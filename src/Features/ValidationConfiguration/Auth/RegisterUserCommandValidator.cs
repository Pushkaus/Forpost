using FluentValidation;
using Forpost.Features.Auth;

namespace Forpost.Features.ValidationConfiguration.Auth;

public sealed class RegisterUserCommandValidator: AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(entity => entity.Model.FirstName)
            .NotEmpty().WithMessage("Имя не должно быть пустым.")
            .MaximumLength(15).WithMessage("Имя не должно превышать 15 символов.");

        RuleFor(entity => entity.Model.LastName)
            .NotEmpty().WithMessage("Фамилия не должна быть пустой.")
            .MaximumLength(20).WithMessage("Фамилия не должна превышать 20 символов.");

        RuleFor(entity => entity.Model.Patronymic)
            .MaximumLength(20).WithMessage("Отчество не должно превышать 20 символов.");

        RuleFor(entity => entity.Model.PhoneNumber)
            .NotEmpty().WithMessage("Номер телефона обязателен.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Некорректный номер телефона.");

        RuleFor(entity => entity.Model.Email)
            .NotEmpty().WithMessage("Email обязателен.")
            .EmailAddress().WithMessage("Некорректный формат email.");

        RuleFor(entity => entity.Model.Role)
            .NotEmpty().WithMessage("Роль обязательна.")
            .MaximumLength(30).WithMessage("Роль не должна превышать 30 символов.");

        RuleFor(entity => entity.Model.Password)
            .NotEmpty().WithMessage("Пароль обязателен.")
            .MaximumLength(20);
    }
}