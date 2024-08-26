namespace Forpost.Business.Auth.Commands;

public class LoginUserCommand
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Password { get; set; } = default!;
}