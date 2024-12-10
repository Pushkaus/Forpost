using Forpost.Domain.TelegramData;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Collections.Concurrent;
using Forpost.TelegramBot.Commands.Auth;
using Forpost.TelegramBot.Commands.Start;

namespace Forpost.TelegramBot.Commands;

public sealed class CommandRegistry
{
    private readonly ConcurrentDictionary<string, ITelegramBotCommandHandler> _commandHandlers;
    private readonly IServiceProvider _serviceProvider;
    private readonly ITelegramUserAuthDomainRepository _userAuthDomainRepository;
    private readonly ITelegramBotClient _telegramBotClient;

    public CommandRegistry(
        IServiceProvider serviceProvider,
        ITelegramUserAuthDomainRepository userAuthDomainRepository,
        ITelegramBotClient telegramBotClient)
    {
        _serviceProvider = serviceProvider;
        _userAuthDomainRepository = userAuthDomainRepository;
        _telegramBotClient = telegramBotClient;
        _commandHandlers = new ConcurrentDictionary<string, ITelegramBotCommandHandler>(
            serviceProvider.GetServices<ITelegramBotCommandHandler>().ToDictionary(h => h.Command));
    }

    public async Task HandleCommandAsync(Update update, CancellationToken cancellationToken)
    {
        if (update?.Type != UpdateType.Message || update.Message?.Text == null)
            return;

        var message = update.Message;
        var chatId = message.Chat.Id;
        var messageText = message.Text;
        
        var user = await _userAuthDomainRepository.GetByTelegramIdAsync(chatId, cancellationToken);
        
        if (user == null || !user.IsAuthorized)
        {
            var authHandler = _commandHandlers.Values.OfType<StartCommand>().FirstOrDefault();
            if (authHandler != null)
            {
                await authHandler.HandleAsync(update, cancellationToken);
            }
            return;
        }
        
        // if (user == null || !user.IsAuthorized)
        // {
        //     var authHandler = _commandHandlers.Values.OfType<StartHandler>().FirstOrDefault();
        //     if (authHandler != null)
        //     {
        //         await authHandler.HandleAsync(update, cancellationToken);
        //     }
        //     return;
        // }
        
        if (messageText.StartsWith("/") && user.IsAuthorized)
        {
            var command = messageText.Split(' ')[0];
            if (_commandHandlers.TryGetValue(command, out var handler))
            {
                await handler.HandleAsync(update, cancellationToken);
            }
        }
    }
}