
using Forpost.Web.Client.Implementations;

namespace Forpost.IntegrationTests.Auth;

public sealed class AccountControllerTest : BaseTest
{
    public AccountControllerTest(TestApplication application) : base(application)
    {
    }
    /// <summary>
    /// Успешная авторизация 
    /// </summary>
    [Fact(DisplayName = "Успешный логин")]
    public async Task Auth_ValidInput_Return200Ok()
    {
        // Arrange
        var validUser = new LoginUserRequest { FirstName = "test", LastName = "test", Password = "123" };

        // Act
        var token = await Client.AccountClient.LoginAsync(validUser);

        // Assert
        token.Should().NotBeNull();
    }
}