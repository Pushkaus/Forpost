using Forpost.Common.Extensions;
using Forpost.Domain.Primitives.DomainAbstractions;
using Forpost.Store.Postgres;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    private const int BatchSize = 100;
    
    private static readonly JsonSerializerSettings JsonSerializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.Auto
    };

    private readonly TimeProvider _timeProvider;
    private readonly ILogger<OutboxMessagesJob> _logger;
    private readonly IPublisher _publisher;
    private readonly IServiceProvider _serviceProvider;

    public OutboxMessagesJob(
        IPublisher publisher,
        TimeProvider timeProvider,
        ILogger<OutboxMessagesJob> logger, 
        IServiceProvider serviceProvider)
    {
        _publisher = publisher;
        _timeProvider = timeProvider;
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        var options = scope.ServiceProvider.GetRequiredService<DbContextOptions<ForpostContextPostgres>>();
        
        var dbContext = new ForpostContextPostgres(options);
        var outboxMessages = await dbContext.Set<OutboxMessage>()
            .Where(message => message.ProcessedOnUtc == null && string.IsNullOrEmpty(message.Error))
            .Take(BatchSize)
            .ToListAsync();

        if (outboxMessages.IsEmpty())
            return;

        foreach (var outboxMessage in outboxMessages)
        {
            try
            {
                var domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(outboxMessage.Content, JsonSerializerSettings)!;
                await _publisher.Publish(domainEvent, context.CancellationToken);
            }
            catch (Exception exception)
            {
                outboxMessage.Error = exception.Message;
                _logger.LogError("Произошла ошибка обработки OutboxMessage {outboxMessageId}", outboxMessage.Id);
            }
            finally
            {
                outboxMessage.ProcessedOnUtc = _timeProvider.GetUtcNow();
                dbContext.Update(outboxMessage);
            }
        }

        var handledMessages = outboxMessages.Where(message =>
            string.IsNullOrEmpty(message.Error) && message.ProcessedOnUtc.HasValue);
        
        dbContext.RemoveRange(handledMessages);
        
        await dbContext.SaveChangesAsync();
    }
    
}
