namespace Forpost.Domain.ProductCreating.ManufacturingProcesses;

public enum ManufacturingProcessStatus
{
    Pending = 100,
    InPaused = 101,
    InProgress = 200,
    Completed = 300,
    Cancelled = 400
}