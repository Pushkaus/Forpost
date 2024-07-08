namespace Forpost.Web.Contracts.Models.Storages;

public class StorageCreateModel
{
    public string Name { get; set; }
    public Guid ResponsibleId { get; set; }
}