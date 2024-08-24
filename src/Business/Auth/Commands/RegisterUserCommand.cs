namespace Forpost.Business.Auth.Commands;

public class RegisterUserCommand
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;    
    public string? Patronymic { get; set; }
    public string Post { get; set; } = default!;
    public string Role { get; set; } = default!;
    public string? Email { get; set; }
    public string PhoneNumber { get; set; } = default!;
    public string Password { get; set; } = default!;
}