using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using Forpost.Application.Contracts.CRM.InvoiceManagement.InvoiceProducts;
using Forpost.Application.Contracts.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;
using Forpost.Domain.ProductCreating.ManufacturingOrders.Contracts;
using Microsoft.Extensions.Logging;
using Moq;

namespace Forpost.Features.UnitTests;

public abstract class UnitTestBase
{
    private readonly IMapper _mapper;
    protected readonly IFixture AutoFixture = new Fixture().Customize(new AutoMoqCustomization());
    protected static readonly CancellationToken CancellationTokenNone = CancellationToken.None;
    
    protected readonly Mock<IInvoiceProductReadRepository> InvoiceProductReadRepositoryMock;
    protected readonly Mock<IManufacturingOrderCompositionReadRepository> ManufacturingOrderCompositionReadRepositoryMock;
    protected readonly Mock<IManufacturingOrderDomainRepository> ManufacturingOrderDomainRepositoryMock;

    protected UnitTestBase()
    {
        InvoiceProductReadRepositoryMock = AutoFixture.Freeze<Mock<IInvoiceProductReadRepository>>();
        ManufacturingOrderCompositionReadRepositoryMock =
            AutoFixture.Freeze<Mock<IManufacturingOrderCompositionReadRepository>>();
        ManufacturingOrderDomainRepositoryMock =
            AutoFixture.Freeze<Mock<IManufacturingOrderDomainRepository>>();
        

        AutoFixture.Register(() => TimeProvider.System);
        AutoFixture.Register(Mock.Of<ILogger>);
        _mapper = new MapperConfiguration(opt =>
        {
            var profileTypes = FeatureAssemblyReference.Assembly.Types()
                .Where(type => typeof(Profile).IsAssignableFrom(type));

            foreach (var profileType in profileTypes)
            {
                opt.AddProfile(profileType);
            }
        }).CreateMapper();
        
        AutoFixture.Register(() => _mapper);
    }
}