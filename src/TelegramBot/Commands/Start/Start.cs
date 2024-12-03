using Forpost.Domain.TelegramData;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Forpost.TelegramBot.Commands.Start;

internal sealed class Start : BaseCommandHandler
{
    private readonly ITelegramUserAuthDomainRepository _telegramUserAuthDomainRepository;

    public Start(
        ITelegramBotClient botClient,
        ITelegramUserAuthDomainRepository telegramUserAuthDomainRepository)
        : base(botClient)
    {
        _telegramUserAuthDomainRepository = telegramUserAuthDomainRepository;
    }

    public override string Command => "/start";

    public override async Task HandleAsync(Update update, CancellationToken cancellationToken)
    {
        if (update.Message != null)
        {
            var user = await _telegramUserAuthDomainRepository.GetUserByTelegramIdAsync(update.Message.Chat.Id,
                cancellationToken);
            if (user is { IsAuthorized: true })
            {
                var messageText = "Вы успешно авторизованы!";
                await BotClient.SendTextMessageAsync(update.Message.Chat.Id, messageText,
                    cancellationToken: cancellationToken);
            }
            else
            {
                await BotClient.SendTextMessageAsync(update.Message.Chat.Id, "help",
                    cancellationToken: cancellationToken);
            }
        }
    }
}