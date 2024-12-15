namespace Forpost.Web.Contracts.Crm.IssueHistories;

public sealed class IssueHistoryRequest
{
    public Guid? ExecutorId { get; set; } 
    public Guid? ResponsibleId { get; set; } 
    public int? Month { get; set; } 
    public int? Year { get; set; }
    public int Skip { get; set; } = 0;
    public int Limit { get; set; } = 10;
}