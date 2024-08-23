namespace Forpost.Common.Exceptions;

/// <summary>
/// Сущность не найдена
/// </summary>
public sealed class EntityNotFoundException(string message) : ForpostExceptionBase(message)
{
    public override string ErrorCode => "entity_not_found";
}