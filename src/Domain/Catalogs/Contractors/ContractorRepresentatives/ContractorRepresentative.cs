using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.Contractors.ContractorRepresentatives;

public sealed class ContractorRepresentative : DomainEntity
{
    public Guid ContractorId { get; private set; }
    public string Name { get; private set; }
    public string? Post { get; private set; }
    public string? Description { get; private set; }

    public static ContractorRepresentative Add(
        Guid contractorId,
        string name,
        string post,
        string? description) =>
        new(contractorId, name, post, description);

    private ContractorRepresentative(
        Guid contractorId,
        string name,
        string? post,
        string? description)
    {
        ContractorId = contractorId;
        Name = name;
        Post = post;
        Description = description;
    }
}