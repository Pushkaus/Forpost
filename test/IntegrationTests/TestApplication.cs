using Forpost.Store.Postgres;
using Forpost.Web.Client;
using Forpost.Web.Host;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Testcontainers.PostgreSql;

namespace Forpost.IntegrationTests;

public sealed class TestApplication: WebApplicationFactory<IApiMarker>, IAsyncLifetime
{
    private static class DockerImages
    {
        public static string PostgresSql => "postgres:latest";
    }
    
    private const string UserName = "postgres";
    private const string Password = "postgres";
    private const string DatabaseName = "ErpDatabaseTests";
    private const string ContainerNamePrefix = "ForpostTests";
    
    private readonly PostgreSqlContainer _dbContainer =
        new PostgreSqlBuilder()
            .WithImage(DockerImages.PostgresSql)
            .WithUsername(UserName)
            .WithPassword(Password)
            .WithDatabase(DatabaseName)
            .WithName($"{ContainerNamePrefix}_PostgreSql_{Guid.NewGuid()}")
            .Build();

    
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {   
            services.AddForpostClients(CreateClient);
        });
        
        var overridenConfiguration = new Dictionary<string, string>()
        {
            { "ConnectionStrings:ErpDatabase", _dbContainer.GetConnectionString() }
        };

        builder.ConfigureAppConfiguration(x => x.AddInMemoryCollection(overridenConfiguration!));

        return base.CreateHost(builder);
    }
    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
    }

    public new async Task DisposeAsync()
    {
        await _dbContainer.StopAsync(); 
    }
}