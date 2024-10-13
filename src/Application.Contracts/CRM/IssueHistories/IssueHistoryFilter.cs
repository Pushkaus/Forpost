namespace Forpost.Application.Contracts.CRM.IssueHistories;

public sealed class IssueHistoryFilter
{
    public Guid? ExecutorId { get; set; } 
    public Guid? ResponsibleId { get; set; } 
    public int? Month { get; set; } 
    public int? Year { get; set; } 
    public int Skip { get; set; }
    public int Limit { get; set; }
}