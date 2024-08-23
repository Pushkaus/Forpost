using AutoMapper;
using Forpost.Business.EventHanding;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Abstract;

/// <summary>
/// Шаблон для сервисов, с только с часто используемой необходимой инфраструктурой
/// </summary>
internal abstract class BusinessService
{
    protected IDbUnitOfWork DbUnitOfWork;
    protected ILogger<BusinessService> Logger;
    protected IMapper Mapper;
    protected IConfiguration Configuration;
    protected IDomainEventBus DomainEventBus;
    protected TimeProvider TimeProvider;

    protected BusinessService(IDbUnitOfWork dbUnitOfWork,
        ILogger<BusinessService> logger, 
        IMapper mapper,
        IConfiguration configuration,
        IDomainEventBus domainEventBus,
        TimeProvider timeProvider)
    {
        DbUnitOfWork = dbUnitOfWork;
        Logger = logger;
        Mapper = mapper;
        TimeProvider = timeProvider;
        DomainEventBus = domainEventBus;
        Configuration = configuration;
    }
}