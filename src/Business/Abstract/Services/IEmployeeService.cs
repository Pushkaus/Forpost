using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services;

public interface IEmployeeService: IBusinessService
{
    public Task<IReadOnlyList<Employee>> GetAllAsync(CancellationToken cancellationToken);
}