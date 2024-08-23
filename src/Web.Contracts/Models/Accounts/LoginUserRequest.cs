namespace Forpost.Web.Contracts.Models.Accounts;

public class LoginUserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}