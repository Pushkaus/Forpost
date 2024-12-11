using Forpost.Application.Contracts;
using Mediator;

namespace Forpost.Infrastructure.Pipeline;

internal sealed class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IMessage
{
    private readonly IDbUnitOfWork _unitOfWork;

    public UnitOfWorkBehavior(IDbUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async ValueTask<TResponse> Handle(TRequest message, CancellationToken cancellationToken, MessageHandlerDelegate<TRequest, TResponse> next)
    {

        if (IsWriteOperation() is false)
        {
            return await next(message, cancellationToken);
        }
        
        var response = await next(message, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return response;
    }
    
    private static bool IsWriteOperation() => typeof(TRequest).Name.EndsWith("Command") 
                                              || typeof(TRequest).Name.EndsWith("Handler");
}