namespace Forpost.Web.Contracts.StorageManagement.StorageProduct;

public class StorageReponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ResponsibleId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
}