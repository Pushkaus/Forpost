using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Forpost.TelegramBot
{
    public class TelegramPollingService : BackgroundService
    {
        private readonly ITelegramBotClient _botClient;
        private CancellationTokenSource _cancellationTokenSource;

        public TelegramPollingService(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);
            return Task.Run(() => StartPolling(_cancellationTokenSource.Token), stoppingToken);
        }

        private async Task StartPolling(CancellationToken cancellationToken)
        {
            int offset = 0; // Начальное значение смещения
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    // Получение обновлений
                    var updates = await _botClient.GetUpdatesAsync(offset, cancellationToken: cancellationToken);
                    foreach (var update in updates)
                    {
                        // Устанавливаем смещение для получения только новых обновлений
                        offset = update.Id + 1; 
                        await HandleUpdate(update);
                    }
                }
                catch (Exception ex)
                {
                    // Логгируем ошибки (по необходимости, можно настроить логгирование)
                    Console.WriteLine($"Ошибка при обработке обновлений: {ex.Message}");
                }
            }
        }

        private async Task HandleUpdate(Update update)
        {
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message && update.Message.Text != null)
            {
                var message = update.Message;
                // Ответ на полученное сообщение
                await _botClient.SendTextMessageAsync(message.Chat.Id, $"Вы написали: {message.Text}");
            }
        }
    }
}
