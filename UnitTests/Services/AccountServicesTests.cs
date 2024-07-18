using AutoFixture;
using FluentAssertions;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Services;
using Forpost.Common.Exceptions;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Identity;
using Moq;
using static Forpost.UnitTests.TestData.Employee;

namespace Forpost.UnitTests.Services;

public sealed class AccountServicesTests: BaseUnitTest
{
    private readonly IAccountService sut;
    private readonly Mock<IEmployeeRepository> employeeRepositoryMock;
    private readonly Mock<IRoleRepository> roleRepositoryMock;
    private readonly Mock <IPasswordHasher<Employee>> passwordHasherMock;


    public AccountServicesTests()
    {
        employeeRepositoryMock = AutoFixture.Freeze<Mock<IEmployeeRepository>>();
        roleRepositoryMock = AutoFixture.Freeze<Mock<IRoleRepository>>();
        passwordHasherMock = AutoFixture.Freeze<Mock<IPasswordHasher<Employee>>>();
        sut = AutoFixture.Create<AccountService>();
    }
    
    [Fact(DisplayName = "Регистрация сотрудника. Указана валидная модель сотрудника. Успешная регистрация")]
    public async Task RegisterAsync_ModelDeclared_Should_Return_EmployeeUser()
    {
        // Arrange
        employeeRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Employee>()));
        roleRepositoryMock.Setup(x => x.GetByNameAsync("Admin")).ReturnsAsync(new Role("Admin"));
        passwordHasherMock.Setup(x => x.HashPassword(It.IsAny<Employee>(), It.IsAny<string>())).Returns("123") ;
        var user = GetValidUser(x => x.Role = "Admin");
        // Act
        var act = async () => await sut.RegisterAsync(user);
        // Assert
        await act.Should().NotThrowAsync();
    }

    [Fact(DisplayName = "Регистрация сотрудника. Неправильно указана роль. Исключение NotFound")]
    public async Task RegisterAsync_InvalidRole_Should_Return_NotFound()
    {
        // Arrange
        employeeRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Employee>()));
        roleRepositoryMock.Setup(x => x.GetByNameAsync(It.IsAny<string>())).ReturnsAsync((Role?)null);
        passwordHasherMock.Setup(x => x.HashPassword(It.IsAny<Employee>(), It.IsAny<string>())).Returns("123");
        var user = GetValidUser(x => x.Role = "Admin");
        // Act
        var act = async () => await sut.RegisterAsync(user);
        // Assert
        await act.Should().ThrowAsync<EntityNotFoundException>();
    }
}