namespace Forpost.Application.Contracts.Catalogs.Employees;

public sealed class EmployeeFilter
{
    public string? Lastname { get; set; }
    public int Skip { get; set; } = 0;
    public int Limit { get; set; } = 10;
}