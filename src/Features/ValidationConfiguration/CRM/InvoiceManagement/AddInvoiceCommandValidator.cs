using FluentValidation;
using Forpost.Features.Crm.InvoiceManagement.Invoices;


namespace Forpost.Features.ValidationConfiguration.CRM.InvoiceManagement;

public sealed class AddInvoiceCommandValidator : AbstractValidator<AddInvoiceCommand>
{
    public AddInvoiceCommandValidator()
    {
        RuleFor(command => command.Number)
            .NotEmpty().WithMessage("Номер счета не может быть пустым.");

        RuleFor(command => command.ContractorId)
            .NotEqual(Guid.Empty).WithMessage("ИД контрагента не может быть пустым.");

        RuleFor(command => command.Products)
            .NotEmpty().WithMessage("Должен быть хотя бы один продукт в счете.");
            
    }
}