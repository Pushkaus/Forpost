namespace Forpost.Web.Contracts.Models.Storages;

public class StorageCreateRequest
{
    public string Name { get; set; }
    public Guid ResponsibleId { get; set; }
}