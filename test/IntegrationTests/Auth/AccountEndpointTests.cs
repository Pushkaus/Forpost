using Forpost.Web.Client.Implementations;
using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Http;


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
        var validUser = new LoginUserRequest { FirstName = "test", LastName = "test", Password = "123" };
        
        // Act
        var token = await Client.AccountClient.Account_LoginAsync(validUser);

        // Assert
        token.Should<string>();
        token.Should().NotBeNull();
    }
    
    /// <summary>
    /// Неудачная авторизация 
    /// </summary>
    [Fact(DisplayName = "Неудачный логин")]
    public async Task Auth_NotValidInput_Return400BadRequest()
    {
        var validUser = new LoginUserRequest { FirstName = "test", LastName = "test", Password = "21312312" };
        
        // Act
        Func<Task> act = async () => await Client.AccountClient.Account_LoginAsync(validUser);
        
        // Assert
        await act.Should().ThrowAsync<ApiException>().Where(ex => ex.StatusCode == (int)HttpStatusCode.BadRequest);

    }
    /// <summary>
    /// Успешная регистрация
    /// </summary>
    [Fact(DisplayName = "Успешная регистрация")]
    public async Task Register_ValidInput_Return201Created()
    {
        // Arrange
        var newUser = new RegisterUserRequest
        {
            FirstName = "John",
            LastName = "Doe",
            Patronymic = "Smith",
            Post = "Manager",
            Role = "Admin",
            Email = "john.doe@example.com",
            PhoneNumber = "1234567890",
            Password = "SecurePassword123"
        };

        // Act
        var employeeId = await Client.AccountClient.Account_RegisterAsync(newUser);
        // Assert
        employeeId.Should().NotBeEmpty();
        employeeId.Should<Guid>();
    }
    /// <summary>
    /// Успешная регистрация
    /// </summary>
    [Fact(DisplayName = "Неудачная регистрация")]
    public async Task Register_NotValidInput_Return400()
    {
        // Arrange
        var newUser = new RegisterUserRequest
        {
            FirstName = "",
            LastName = "Doe",
            Patronymic = "Smith",
            Post = "Manager",
            Role = "Admin",
            Email = "john.doe@example.com",
            PhoneNumber = "1234567890",
            Password = "SecurePassword123"
        };
        // Act
        Func<Task> act = async () => await Client.AccountClient.Account_RegisterAsync(newUser);
    
        // Assert
        await act.Should().ThrowAsync<ApiException>().Where(ex => ex.StatusCode == (int)HttpStatusCode.UnprocessableEntity);
    }
}