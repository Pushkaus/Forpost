using Forpost.Common;
using Forpost.Domain.Primitives.DomainAbstractions;
using Forpost.Store.Repositories;
using Forpost.TelegramBot.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace Forpost.TelegramBot;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTelegramBot(this IServiceCollection services, IConfiguration configuration)
    {
        const string telegramBotToken = "7874827881:AAE3OG_rOg5DDS48d4DjwB3D4yXbCatlk_g";
        services.AddSingleton<ITelegramBotClient>(new TelegramBotClient(telegramBotToken));
        return services.AddTelegramBotHandlers();
    }

    private static IServiceCollection AddTelegramBotHandlers(this IServiceCollection services)
    {
       return services.AddAllTypesAssignableMarkerInterfaceTo<ITelegramBotSender>(TelegramBotAssemblyReference.Assembly,
            ServiceLifetime.Transient);
    }
}