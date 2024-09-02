using Forpost.Store.Postgres;
using Forpost.Web.Client;
using Forpost.Web.Contracts.Auth;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Forpost.IntegrationTests.AuthTests;

public sealed class AccountControllerTest : IClassFixture<TestApplication>, IAsyncLifetime
{
    private readonly IForpostApiClient _forpostApiClient;
    private readonly HttpClient _httpClient;
    private readonly ForpostContextPostgres _context;
    
    public AccountControllerTest(TestApplication application)
    {
        _httpClient = application.CreateClient();
        _forpostApiClient = application.Services.GetRequiredService<IForpostApiClient>();
        _context = application.Services.GetRequiredService<ForpostContextPostgres>();
    }

    [Fact]
    public async Task SuccessfulLogin()
    {
        // Arrange
        var validUser = new LoginUserRequest
        {
            FirstName = "test",
            LastName = "test",
            Password = "123"
        };

        // Act
        var token = await _forpostApiClient.AccountClient.LoginAsync(
            firstName: validUser.FirstName, 
            lastName: validUser.LastName, 
            password: validUser.Password
        );

        // Assert
        Assert.NotNull(token);
    }

    public Task InitializeAsync() => Task.CompletedTask;

    public Task DisposeAsync() => Task.CompletedTask;
}