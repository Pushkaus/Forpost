using Forpost.Domain.Catalogs.Employees;
using Forpost.Domain.TelegramData;
using Forpost.TelegramBot.Models.Auth;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Forpost.TelegramBot.Commands.Auth;

internal sealed class Auth: BaseTelegramCommandHandler
{
    private readonly ITelegramUserAuthDomainRepository _userAuthDomainRepository;
    private readonly IEmployeeDomainRepository _employeeDomainRepository;
    
    public Auth(
        ITelegramBotClient botClient,
        ITelegramUserAuthDomainRepository userAuthDomainRepository,
        IEmployeeDomainRepository employeeDomainRepository) : base(botClient)
    {
        _userAuthDomainRepository = userAuthDomainRepository;
        _employeeDomainRepository = employeeDomainRepository;
    }

    public override string Command => "/auth";
    
    public override Task HandleAsync(Update update, CancellationToken cancellationToken)
    {
        var authModel = new AuthModelCache();
        
    }
}