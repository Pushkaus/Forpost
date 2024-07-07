namespace Forpost.Web.Contracts.Models.Accounts;

public class LoginUserRequest
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string password { get; set; }
}