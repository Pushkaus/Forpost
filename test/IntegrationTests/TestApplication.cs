using System.Net.Http.Headers;
using Forpost.Host;
using Forpost.Store.Migrations;
using Forpost.Web.Client;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        builder.ConfigureServices(services => { services.AddForpostClients(AuthorizedClient); });

        var overridenConfiguration = new Dictionary<string, string>
        {
            { "ConnectionStrings:ErpDatabase", _dbContainer.GetConnectionString() }
        };

        builder.ConfigureAppConfiguration(x => x.AddInMemoryCollection(overridenConfiguration!));

        return base.CreateHost(builder);
    }

    private HttpClient AuthorizedClient()
    {
        var client = CreateClient();
        const string token =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRlc3QiLCJmYW1pbHlfbmFtZSI6InRlc3QiLCJuYW1laWQiOiIxNTQ5MmUzMC04ZGYzLTEzMmYtOWRlNi0zZmNkOTFlMzg5MjMiLCJyb2xlIjoiMDU0OTJlMzAtOGRmMy00MzJmLTlkZTYtM2ZjZDkxZTM4OWY1IiwibmJmIjoxNzI2MDQxNjI2LCJleHAiOjE3MjY2NDY0MjYsImlhdCI6MTcyNjA0MTYyNn0.-u4dyiiKw6JZYyTwRKKKXsp2bsDl5HzKj0XH9vgPZKk";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return client;
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
        var configuration = Services.GetRequiredService<IConfiguration>();
        await MigrationManager.MigrateSchema(configuration);
        await MigrationManager.MigrateData(configuration);
    }

    public new async Task DisposeAsync()
    {
        await _dbContainer.StopAsync(); 
    }
}