namespace Forpost.Common.EntityAnnotations;

public interface ITimeFrameEntity
{
    public DateTimeOffset StartTime { get; }
    public DateTimeOffset? EndTime { get; }
}