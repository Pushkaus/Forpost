using Forpost.Store.Postgres;
using Forpost.Web.Client;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.IntegrationTests;

public abstract class BaseTests:IClassFixture<TestApplication>, IAsyncLifetime
{
    protected readonly IForpostApiClient Client;

    protected readonly ForpostContextPostgres DbContext;

    protected BaseTests(TestApplication application)
    {
        Client = application.Services.GetRequiredService<IForpostApiClient>();
        DbContext = application.Services.GetRequiredService<ForpostContextPostgres>();
    }

    public Task InitializeAsync() => Task.CompletedTask;

    public Task DisposeAsync() => Task.CompletedTask;
}