namespace Forpost.Business.Catalogs.Storages;

public class StorageCreateCommand
{
    public string Name { get; set; } = default!;
    public Guid ResponsibleId { get; set; }
}