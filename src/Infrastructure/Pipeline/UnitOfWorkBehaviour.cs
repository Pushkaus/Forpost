using Forpost.Application.Contracts;
using Forpost.Store.Postgres;
using MediatR;

namespace Forpost.Infrastructure.Pipeline;

public sealed class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IDbUnitOfWork _unitOfWork;

    public UnitOfWorkBehavior(IDbUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (IsWriteOperation() is false)
        {
            return await next();
        }

        var response = await next();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return response;
    }

    private static bool IsWriteOperation() => typeof(TRequest).Name.EndsWith("Command");
}