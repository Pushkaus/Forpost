namespace Forpost.Application.Contracts.Catalogs.TechCards;

public sealed class TechCardFilter
{
    public string? Number { get; set; }
    public Guid? ProductId { get; set; }
    public int Skip { get; set; } = 10;
    public int Limit { get; set; } = 10;
}