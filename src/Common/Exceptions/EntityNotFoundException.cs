namespace Forpost.Common.Exceptions;

/// <summary>
/// Сущность не найдена
/// </summary>
public sealed class EntityNotFoundException : ForpostExceptionBase
{
    public EntityNotFoundException(string message) : base(message)
    {
    }

    public override string ErrorCode => "entity_not_found";
}