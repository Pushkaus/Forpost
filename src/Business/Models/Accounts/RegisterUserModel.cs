namespace Forpost.Business.Models.Accounts;

public class RegisterUserModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Patronymic { get; set; }
    public string Post { get; set; }
    public string Role { get; set; }
    public string? Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}