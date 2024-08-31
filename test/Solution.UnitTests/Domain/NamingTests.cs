using Forpost.Domain;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Solution.UnitTests.Domain;

public sealed class NamingTests
{
    private const string PastSimpleEnding = "ed";
    private readonly HashSet<Type> _exceptionRule = [typeof(ContractorAdded)];

    [Fact(DisplayName = $"Типы доменных событий должны иметь заканчиваться на {PastSimpleEnding}")]
    public void DomainEvents_Should_EndsWith_Past_Simple_Ending()
    {
        //Arrange
        var domainEvents = DomainAssemblyReference.Assembly.GetTypes()
            .Where(type => typeof(IDomainEvent).IsAssignableFrom(type) && type is { IsInterface: false, IsAbstract: false })
            .Except(_exceptionRule)
            .ToList();
        //Assert
        domainEvents.Should().AllSatisfy(domainEvent => domainEvent.Name.EndsWith(PastSimpleEnding));
    }
}