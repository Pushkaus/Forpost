using Forpost.Domain;
using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Solution.UnitTests.Domain;

public sealed class TypeDefinitionTests
{
    [Fact(DisplayName = "Все доменные сущности в сборке должны быть sealed")]
    public void DomainTypes_Should_BeSealed()
    {
        //Arrange
        var domainEntities = DomainAssemblyReference.Assembly.GetTypes()
            .Where(type => typeof(DomainEntity).IsAssignableFrom(type)).ToList();
        var sealedDomainEntities = domainEntities.Where(type => type.IsSealed);
        //Act
        var notSealedEntities = domainEntities.Except(sealedDomainEntities);
        //Assert
        notSealedEntities.Should().BeEmpty();
    }
}