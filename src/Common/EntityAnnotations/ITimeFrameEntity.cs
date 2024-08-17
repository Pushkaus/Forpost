namespace Forpost.Common.EntityAnnotations;

public interface ITimeFrameEntity
{
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
}