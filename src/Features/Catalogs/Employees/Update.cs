using AutoMapper;
using Forpost.Domain.Catalogs.Employees;
using Mediator;

namespace Forpost.Features.Catalogs.Employees
{
    public class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand>
    {
        private readonly IEmployeeDomainRepository _domainRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IEmployeeDomainRepository domainRepository, IMapper mapper)
        {
            _domainRepository = domainRepository;
            _mapper = mapper;
        }

        public async ValueTask<Unit> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = await _domainRepository.GetByIdAsync(command.Id, cancellationToken);
            _mapper.Map(command, employee);
            _domainRepository.Update(employee);
            return Unit.Value;
        }
    }

    public record UpdateEmployeeCommand(
        Guid Id,
        string FirstName,
        string LastName,
        string? Patronymic,
        string Post,
        Guid RoleId,
        string? Email,
        string PhoneNumber) : ICommand;
}