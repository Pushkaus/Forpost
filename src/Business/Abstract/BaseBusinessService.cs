using AutoMapper;
using Forpost.Business.EventHanding;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Abstract;

/// <summary>
/// Шаблон для сервисов, с только с часто используемой необходимой инфраструктурой
/// </summary>
internal abstract class BaseBusinessService
{
    protected IDbUnitOfWork DbUnitOfWork;
    protected ILogger<BaseBusinessService> Logger;
    protected IMapper Mapper;
    protected IConfiguration Configuration;
    protected TimeProvider TimeProvider;

    protected BaseBusinessService(IDbUnitOfWork dbUnitOfWork,
        ILogger<BaseBusinessService> logger, 
        IMapper mapper,
        IConfiguration configuration, 
        TimeProvider timeProvider)
    {
        DbUnitOfWork = dbUnitOfWork;
        Logger = logger;
        Mapper = mapper;
        TimeProvider = timeProvider;
        Configuration = configuration;
    }
}