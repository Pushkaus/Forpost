namespace Forpost.Domain.Primitives.EntityAnnotations;

public interface ITimeFrameEntity
{
    public DateTimeOffset? StartTime { get; }
    public DateTimeOffset? EndTime { get; }
}