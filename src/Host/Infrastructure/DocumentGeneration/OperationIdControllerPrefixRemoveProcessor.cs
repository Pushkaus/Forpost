using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace Forpost.Host.Infrastructure.DocumentGeneration;

internal sealed class OperationIdControllerPrefixRemoveProcessor : IOperationProcessor
{
    public bool Process(OperationProcessorContext context)
    {
        foreach (var operationDescription in context.AllOperationDescriptions)
        {
            var operationIdWithControllerPrefix = operationDescription.Operation.OperationId;
            var operationIdWithoutControllerPrefix = operationIdWithControllerPrefix.Split('_').LastOrDefault();

            operationDescription.Operation.OperationId = operationIdWithoutControllerPrefix;
        }
        return true;
    }
}