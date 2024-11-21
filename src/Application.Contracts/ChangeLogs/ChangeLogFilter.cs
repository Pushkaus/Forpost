namespace Forpost.Application.Contracts.ChangeLogs;

public sealed class ChangeLogFilter
{
    public int Skip { get; set; } = 0;
    public int Limit { get; set; } = 10;
}