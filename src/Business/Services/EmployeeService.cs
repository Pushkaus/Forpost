using AutoMapper;
using Forpost.Business.Abstract;
using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Services;

internal sealed class EmployeeService : BaseBusinessService, IEmployeeService
{
    public EmployeeService(IDbUnitOfWork dbUnitOfWork, 
        ILogger<EmployeeService> logger,
        IMapper mapper,
        IConfiguration configuration, 
        TimeProvider timeProvider) : base(dbUnitOfWork, logger, mapper, configuration, timeProvider)
    {
    }

    public async Task<IReadOnlyList<Employee>> GetAllAsync(CancellationToken cancellationToken)
    {
        var employees = await DbUnitOfWork.EmployeeRepository.GetAllAsync(cancellationToken);
        return employees;
    }
}