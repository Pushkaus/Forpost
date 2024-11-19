namespace Forpost.Application.Contracts.StorageManagement;

public sealed class EntryStorageHistoryFilter
{
    public bool? Purchased { get; set; }
    public int? Days { get; set; }
    public int? Month { get; set; } 
    public int? Year { get; set; }
    public int Skip { get; set; } = 0;
    public int Limit { get; set; } = 10;
}