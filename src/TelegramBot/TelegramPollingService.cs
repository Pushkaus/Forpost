using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Forpost.TelegramBot.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Forpost.TelegramBot;

public class TelegramPollingService : BackgroundService
{
    private readonly ITelegramBotClient _botClient;
    private readonly IServiceProvider _serviceProvider; // Добавляем IServiceProvider

    public TelegramPollingService(ITelegramBotClient botClient, IServiceProvider serviceProvider) // Изменён конструктор
    {
        _botClient = botClient;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _botClient.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync,
            cancellationToken: stoppingToken);

        await Task.Delay(Timeout.InfiniteTimeSpan, stoppingToken);
    }

    private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope()) 
        {
            var commandRegistry = scope.ServiceProvider.GetRequiredService<CommandRegistry>();
            await commandRegistry.HandleCommandAsync(update, cancellationToken);
        }
    }

    private Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
