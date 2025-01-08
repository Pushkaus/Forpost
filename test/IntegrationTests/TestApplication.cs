using System.Net.Http.Headers;
using Forpost.Host;
using Forpost.Store.Migrations;
using Forpost.Web.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Testcontainers.PostgreSql;
using static Forpost.Store.Migrations.MigrationManager;

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
        
        builder.ConfigureServices((_, services) =>
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            MigrateSchema(configuration).GetAwaiter().GetResult();
            MigrateData(configuration).GetAwaiter().GetResult();
        });
        
        return base.CreateHost(builder);
    }

    private HttpClient AuthorizedClient()
    {
        var client = CreateClient();
        const string token =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRlc3QiLCJmYW1pbHlfbmFtZSI6InRlc3QiLCJuYW1laWQiOiIxNTQ5MmUzMC04ZGYzLTEzMmYtOWRlNi0zZmNkOTFlMzg5MjMiLCJyb2xlIjoiMDU0OTJlMzAtOGRmMy00MzJmLTlkZTYtM2ZjZDkxZTM4OWY1IiwibmJmIjoxNzM2MTk2NDc4LCJleHAiOjE3MzY4MDEyNzgsImlhdCI6MTczNjE5NjQ3OH0.o2n8zqAoDTvcCToWoXIfM9GSBi3WT-5SY-zbjGeWsQI";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return client;
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