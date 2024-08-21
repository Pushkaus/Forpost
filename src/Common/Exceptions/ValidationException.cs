namespace Forpost.Common.Exceptions;

/// <summary>
/// Ошибка валидации входных параметров
/// </summary>
public sealed class ValidationException(string message) : ForpostExceptionBase(message)
{
    public override string ErrorCode => "validation_exception";
}