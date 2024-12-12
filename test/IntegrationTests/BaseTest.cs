using Moq;
using Forpost.Common.Utils;
using Forpost.Store.Postgres;
using Forpost.Web.Client;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.IntegrationTests;

public abstract class BaseTest:IClassFixture<TestApplication>, IAsyncLifetime
{
    protected readonly IForpostApiClient Client;

    protected readonly ForpostContextPostgres DbContext;
    protected readonly IIdentityProvider IdentityProvider;
    protected readonly IServiceProvider ServiceProvider;
    protected BaseTest(TestApplication application)
    {
        Client = application.Services.GetRequiredService<IForpostApiClient>();
        var scope = application.Services.CreateScope();
        DbContext = scope.ServiceProvider.GetRequiredService<ForpostContextPostgres>();
        ServiceProvider = application.Services;
        var identityProviderMock = new Mock<IIdentityProvider>();

        identityProviderMock.Setup(x => x.GetUserId()).Returns(Guid.Parse("15492e30-8df3-132f-9de6-3fcd91e38923"));
        identityProviderMock.Setup(x => x.GetRoleId()).Returns(Guid.Parse("05492e30-8df3-432f-9de6-3fcd91e389f5"));
        
        IdentityProvider = identityProviderMock.Object;
    }

    public Task InitializeAsync() => Task.CompletedTask;

    public Task DisposeAsync() => Task.CompletedTask;
}