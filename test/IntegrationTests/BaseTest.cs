using Forpost.Store.Postgres;
using Forpost.Web.Client;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.IntegrationTests;

public abstract class BaseTest:IClassFixture<TestApplication>, IAsyncLifetime
{
    protected readonly IForpostApiClient Client;

    protected readonly ForpostContextPostgres DbContext;
    
    protected readonly IServiceProvider ServiceProvider;

    protected BaseTest(TestApplication application)
    {
        Client = application.Services.GetRequiredService<IForpostApiClient>();
        var scope = application.Services.CreateScope();
        DbContext = scope.ServiceProvider.GetRequiredService<ForpostContextPostgres>();
        ServiceProvider = application.Services;
    }

    public Task InitializeAsync() => Task.CompletedTask;

    public Task DisposeAsync() => Task.CompletedTask;
}