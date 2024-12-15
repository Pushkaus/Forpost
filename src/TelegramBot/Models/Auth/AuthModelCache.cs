namespace Forpost.TelegramBot.Models.Auth;

public sealed class AuthModelCache
{
    public AuthState? Step { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}