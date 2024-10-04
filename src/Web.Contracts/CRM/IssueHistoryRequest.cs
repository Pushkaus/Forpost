namespace Forpost.Web.Contracts.CRM;

public sealed class IssueHistoryRequest
{
    public Guid? executorId { get; set; } 
    public Guid? responsibleId { get; set; } 
    public int? month { get; set; } 
    public int? year { get; set; }
    public int skip { get; set; } = 0;
    public int limit { get; set; } = 10;
}