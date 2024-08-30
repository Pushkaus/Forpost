using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Primitives.DomainAbstractions;
using Forpost.Domain.Primitives.EventHandling;
using Forpost.Features;
using Forpost.Features.Catalogs.Contractors;
using Forpost.Infrastructure.Mediator;
using Forpost.Infrastructure.Pipeline;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Forpost.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining<FeatureAssemblyReference>();
            options.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
        });
        services.RemoveAll(typeof(INotificationHandler<>));
        services.AddTransient<IDomainEventPublisher, DomainEventPublisherAdapter>();
        services.AddDomainEventHandlers();
        
        return services;
    }


    public static void AddDomainEventHandlers(this IServiceCollection services)
    {
        var assembly = FeatureAssemblyReference.Assembly;
        // Найти все типы, реализующие INotificationHandler<>
        var handlerTypes = assembly.GetTypes()
            .Where(t => t.GetInterfaces().Any(i => 
                i.IsGenericType && 
                i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>)))
            .ToList();

        services.AddTransient<IDomainEventHandler<ContractorAdded>, ContractorAddedNotificationHandler>();

        foreach (var handlerType in handlerTypes)
        {
            // Получение типа уведомления из INotificationHandler<T>
            var domainHandlerInterface = handlerType.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>));
            
            var domainEventType = domainHandlerInterface.GenericTypeArguments[0];
            var notificationType = typeof(DomainEventAdapter<>).MakeGenericType(domainEventType);

            var notificationHandler = typeof(INotificationHandler<>).MakeGenericType(notificationType);
            var adapterType = typeof(DomainEventHandlerAdapter<>).MakeGenericType(domainEventType);
            services.AddTransient(notificationHandler, adapterType);
              
        }
    }
}