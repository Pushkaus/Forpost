namespace Forpost.Application.Contracts.StorageManagement;

public sealed class StorageModel
{
    public Guid StorageId { get; set; }
    public string StorageName { get; set; }
    public Guid ResponsibleId { get; set; }
    public string ResponsibleName { get; set; }
}