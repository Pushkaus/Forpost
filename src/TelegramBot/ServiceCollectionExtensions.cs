using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace Forpost.TelegramBot;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTelegramBot(this IServiceCollection services, IConfiguration configuration)
    {
        var telegramBotToken =
            configuration.GetSection("TelegramBot:Token").Value ?? throw new InvalidOperationException();
        services.AddSingleton<ITelegramBotClient>(new TelegramBotClient(telegramBotToken));
        return services;

    }
}