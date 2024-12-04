using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Forpost.TelegramBot.Commands;

public sealed class CommandRegistry
{
    private readonly List<ITelegramBotCommandHandler> _commandHandlers;
    private readonly IServiceProvider _serviceProvider;

    public CommandRegistry(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _commandHandlers = serviceProvider.GetServices<ITelegramBotCommandHandler>().ToList();
    }
    public async Task HandleCommandAsync(Update update, CancellationToken cancellationToken)
    {
        if (update is { Type: UpdateType.Message, Message.Text: not null })
        {
            var command = update.Message.Text;
            var handler = _commandHandlers.FirstOrDefault(h => h.Command == command);
            if (handler != null)
                await handler.HandleAsync(update, cancellationToken);
        }
    }
}