using Forpost.Business.Models.Accounts;
using Forpost.Store.Entities;
namespace Forpost.UnitTests;

public static class TestData
{
    public static class Employee
    {
        public static RegisterUserModel GetValidUser(Action<RegisterUserModel>? modificator = null)
        {
            var model = new RegisterUserModel();
            modificator?.Invoke(model);
            return model;
        }
    }
}