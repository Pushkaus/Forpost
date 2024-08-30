using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Forpost.BackgroundJobs;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Добавить фоновые обработчики
    /// </summary>
    public static IServiceCollection AddBackgroundJobs(this IServiceCollection services)
    {
        services.AddQuartz(options =>
        {
            options.AddForeverJob<OutboxMessagesJob>(intervalSeconds: 10);
        });

        services.AddQuartzHostedService();
        
        return services;
    }

    /// <summary>
    /// Добавить Job, работающий постоянно, пока приложение запущено
    /// </summary>
    /// <param name="options">Настройки</param>
    /// <param name="intervalSeconds">Интервал вызова Job в секундах</param>
    /// <typeparam name="TJob">Тип джоба</typeparam>
    private static IServiceCollectionQuartzConfigurator AddForeverJob<TJob>(
        this IServiceCollectionQuartzConfigurator options, int intervalSeconds)
        where TJob : IJob
    {
        var jobKey = new JobKey(typeof(TJob).Name);
        
        options.AddJob<TJob>(jobKey)
            .AddTrigger(trigger => trigger
                .ForJob(jobKey)
                .WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(intervalSeconds).RepeatForever()));
        return options;
    }
}