namespace Forpost.TelegramBot.Models.Auth;

public enum AuthState
{
    WaitingFirstName,
    WaitingLastName,
    WaitingPassword,
    Completed
}