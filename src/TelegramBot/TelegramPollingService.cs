using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Forpost.TelegramBot
{
    public class TelegramPollingService : BackgroundService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ILogger<TelegramPollingService> _logger;
        private CancellationTokenSource _cancellationTokenSource;

        public TelegramPollingService(ITelegramBotClient botClient, ILogger<TelegramPollingService> logger)
        {
            _botClient = botClient;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);
            // return Task.Run(() => StartPolling(_cancellationTokenSource.Token), stoppingToken);
            return Task.CompletedTask;
        }

        private async Task StartPolling(CancellationToken cancellationToken)
        {
            int offset = 0; // Начальное значение смещения
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var updates = await _botClient.GetUpdatesAsync(offset, cancellationToken: cancellationToken);
                    foreach (var update in updates)
                    {
                        offset = update.Id + 1;
                        await HandleUpdate(update);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Ошибка при обработке обновлений: {0}", ex.Message);
                }
            }
        }

        private async Task HandleUpdate(Update update)
        {
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message && update.Message.Text == "/start")
            {
                var message = update.Message;
                await _botClient.SendTextMessageAsync(message.Chat.Id,
                    $"Тестовое сообщение на /start {message.From.FirstName} {message.From.LastName}");
            }
        }
    }
}