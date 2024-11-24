namespace Forpost.Application.Contracts.Changes;

public sealed class ChangeLogFilter
{
    public int Skip { get; set; } = 0;
    public int Limit { get; set; } = 10;
}