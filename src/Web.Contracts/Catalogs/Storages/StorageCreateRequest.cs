namespace Forpost.Web.Contracts.Catalogs.Storages;

public class StorageCreateRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid ResponsibleId { get; set; }
}