using Forpost.Store.Postgres;
using Forpost.Web.Client;
using Forpost.Web.Contracts.Auth;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Forpost.IntegrationTests.AuthTests;

public sealed class AccountTests : BaseTests
{
    public AccountTests(TestApplication application) : base(application)
    {
    }
    /// <summary>
    /// Успешная авторизация 
    /// </summary>
    [Fact]
    public async Task Auth_ValidInput_Return200Ok()
    {
        // Arrange
        var validUser = new LoginUserRequest
        {
            FirstName = "test",
            LastName = "test",
            Password = "123"
        };

        // Act
        var token = await Client.AccountClient.LoginAsync(
            firstName: validUser.FirstName, 
            lastName: validUser.LastName, 
            password: validUser.Password
        );

        // Assert
        Assert.NotNull(token);
        Assert.IsType<string>(token);
    }
}