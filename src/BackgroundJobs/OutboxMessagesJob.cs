using Forpost.Common.Extensions;
using Forpost.Domain;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Primitives.DomainAbstractions;
using Forpost.Domain.Primitives.EventHandling;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Quartz;

namespace Forpost.BackgroundJobs;

/// <summary>
/// Обработчик событий OutboxMessages
/// </summary>
[DisallowConcurrentExecution]
internal sealed class OutboxMessagesJob : IJob
{
    private const int BatchSize = 10;

    private static readonly Dictionary<string, Type> EventTypes;
    
    static OutboxMessagesJob()
    {
        var eventTypes = DomainAssemblyReference.Assembly.GetTypes()
            .Where(type => !type.IsAbstract && type.IsAssignableTo(typeof(IDomainEvent)))
            .ToList();
        EventTypes = new Dictionary<string, Type>();
        
        foreach (var eventType in eventTypes)
        {
            EventTypes.Add(eventType.Name, eventType);
        }
    }
    
    private static readonly JsonSerializerSettings JsonSerializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.Auto
    };
    
    private readonly ForpostContextPostgres _dbContext;
    private readonly TimeProvider _timeProvider;
    private readonly ILogger<OutboxMessagesJob> _logger;
    private readonly IDomainEventPublisher _publisher;

    public OutboxMessagesJob(ForpostContextPostgres dbContext,
        IDomainEventPublisher publisher, 
        TimeProvider timeProvider,
        ILogger<OutboxMessagesJob> logger)
    {
        _dbContext = dbContext;
        _publisher = publisher;
        _timeProvider = timeProvider;
        _logger = logger;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var outboxMessages = await _dbContext.Set<OutboxMessage>()
            .Where(message => message.ProcessedOnUtc == null && string.IsNullOrEmpty(message.Error))
            .Take(BatchSize)
            .ToListAsync();
        
        if(outboxMessages.IsEmpty())
            return;

        foreach (var outboxMessage in outboxMessages)
        {
            EventTypes.TryGetValue(outboxMessage.Type, out var eventType);
            
            var domainEvent = JsonConvert.DeserializeObject<ContractorAdded>(outboxMessage.Content, JsonSerializerSettings);
            
            if (domainEvent is not null)
            {
                await _publisher.Publish(domainEvent, context.CancellationToken);
                outboxMessage.ProcessedOnUtc = _timeProvider.GetUtcNow();
            }
            else
            {
                outboxMessage.Error = "Ошибка десериализации события";
            }
            outboxMessage.ProcessedOnUtc = _timeProvider.GetUtcNow();
            _dbContext.Update(outboxMessage);
        }
        
        await _dbContext.SaveChangesAsync();
    }
}