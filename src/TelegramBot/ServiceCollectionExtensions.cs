using Forpost.Common;
using Forpost.Domain.Primitives.DomainAbstractions;
using Forpost.Store.Repositories;
using Forpost.TelegramBot.Commands;
using Forpost.TelegramBot.Handlers;
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
        
        services.AddTransient<ITelegramBotClient>(provider => new TelegramBotClient(telegramBotToken));
        services.AddScoped<CommandRegistry>();
        services.AddTelegramBotHandlers();
        services.AddTelegramCommandsHandlers();
        
        return services;
    }

    private static IServiceCollection AddTelegramBotHandlers(this IServiceCollection services)
    {
        return services.AddAllTypesAssignableMarkerInterfaceTo<ITelegramBotHandler>(
            TelegramBotAssemblyReference.Assembly,
            ServiceLifetime.Scoped);
    }

    private static IServiceCollection AddTelegramCommandsHandlers(this IServiceCollection services)
    {
        return services.AddAllTypesAssignableMarkerInterfaceTo<ITelegramBotCommandHandler>(
            TelegramBotAssemblyReference.Assembly,
            ServiceLifetime.Scoped);
    }
}