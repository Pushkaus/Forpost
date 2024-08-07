using System;
using System.Collections.Generic;
using System.Linq;
using Forpost.Store.Entities;
using Forpost.Store.Enums;
using Xunit;

namespace Forpost.ManufacturingProcess.Tests
{
    public class ManufacturingProcessTests
    {
        [Fact]
        public void ViewListIssuesInTheManufacturingProcess()
        {
            var manufacturingProcessId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var product = new Product
            {
                Id = productId,
                Name = "БПС 3000",
                CategoryId = null,
                CreatedAt = default,
                CreatedById = default,
                UpdatedAt = default,
                UpdatedById = default,
                DeletedAt = null,
                DeletedById = null,
                ParentSubProducts = null,
                DaughterSubProducts = null,
                Version = null,
                InvoiceProducts = null,
                StorageProducts = null
            };
            // Arrange
            var manufacturingProcess1 = new Store.Entities.ManufacturingProcess
            {
                Id = manufacturingProcessId,
                Name = "Изготовление БПС 3000",
                Description = null,
                ProductId = productId,
                CreatedAt = default,
                CreatedById = default,
                UpdatedAt = default,
                UpdatedById = default,
                DeletedAt = null,
                DeletedById = null,
                Issues = null,
                Operations = null,
                SubProcesses = null
            };
            var issue1 = new Issue
            {
                Id = default,
                Name = "Пайка БПС 3000",
                Description = null,
                Duration = new TimeSpan(27,2,0,0,0),
                Cost = 0,
                PreviosIssues = null,
                NextIssues = null,
                Operations = null,
                CreatedAt = default,
                CreatedById = default,
                UpdatedAt = default,
                UpdatedById = default,
                DeletedAt = null,
                DeletedById = null
            };
            var issue2 = new Issue
            {
                Id = default,
                Name = "Сборка БПС 3000",
                Description = null,
                Duration = new TimeSpan(7, 2, 0, 0, 0),
                Cost = 0,
                PreviosIssues = new List<Issue> {issue1},
                NextIssues = null,
                Operations = null,
                CreatedAt = default,
                CreatedById = default,
                UpdatedAt = default,
                UpdatedById = default,
                DeletedAt = null,
                DeletedById = null
            };
            var operation1 = new Operation
            {
                Id = Guid.NewGuid(),
                Name = "Пайка"
            };

            var employee1 = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Pasha",
                LastName = "Mirganov",
                Patronymic = null,
                Post = "Gubka",
                RoleId = default,
                Email = null,
                PhoneNumber = "00000000",
                PasswordHash = "11112",
                CreatedAt = default,
                CreatedById = default,
                UpdatedAt = default,
                UpdatedById = default,
                DeletedAt = null,
                DeletedById = null,
                Storages = null,
                Role = new Role("gg")
            };
            issue1.NextIssues = new List<Issue> { issue2 };
            // Act
            Console.WriteLine($"product {product.Name}, \n manufacturingProcess1 {manufacturingProcess1.Name}\n" +
                              $"issue1 {issue1.Name}, issue2 {issue2.Name}, \n" +
                              $"operation1 {operation1.Name}, employee1 {employee1.FirstName}");

            var manProcess = new ManufacturingProcessIstance
            {
                Id = Guid.NewGuid(),
                Template = manufacturingProcess1,
                BatchNumber = 1,
                TargetQuantity = 50,
                CurrentQuantity = 0,
                EndTime = default,
                CreatedAt = default,
                CreatedById = default,
                UpdatedAt = default,
                UpdatedById = default,
                DeletedAt = null,
                DeletedById = null,
                IssuesInstances = null,
                Operations = null,
                SubProcessesIstances = null
            };
            var issueInstance1 = new IssueInstance
            {
                Id = Guid.NewGuid(),
                ManufacturingProcessInstanceId = manProcess.Id,
                ResponsibleEmployeeId = employee1.Id,
                Template = issue1,
                PreviosIssues = null,
                NextIssue = null,
                Status = Status.Pending,
                EndTime = default,
                CreatedAt = default,
                CreatedById = default,
                UpdatedAt = default,
                UpdatedById = default,
                DeletedAt = null,
                DeletedById = null,
                ManufacturingProcessIstance = null
            }
            // Assert
        }
    }
}