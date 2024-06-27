using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

public class InvoiceRepository: IInvoiceRepository
{
    private readonly ForpostContextPostgres _db;

    public InvoiceRepository(ForpostContextPostgres db)
    {
        _db = db;
    }
    public async Task<IActionResult> CreateInvoice(Guid userId, string number, string contragent, string description, CancellationToken cancellationToken)
    {
        try
        {
            var invoice = new Invoice(number, contragent, description, userId, userId);
            await _db.Invoices.AddAsync(invoice, cancellationToken); // Добавляем счет в контекст базы данных
            await _db.SaveChangesAsync(cancellationToken); // Сохраняем изменения в базе данных

            return new OkResult(); // Возвращаем успешный результат
        }
        catch (Exception ex)
        {
            throw new Exception($"Произошла ошибка при добавлении счета: {ex.Message}");
        }
    }

    public async Task<List<Invoice>> GetInvoice(string invoiceNumber, CancellationToken cancellationToken)
    {
        try
        {
            var invoices = await _db.Invoices
                .Where(i => i.Number == invoiceNumber)
                .ToListAsync(cancellationToken);
            
            return invoices;
        }
        catch (Exception ex)
        {
            throw new Exception("Произошла ошибка при получении счетов.", ex);
        }
    }


    public Task<IActionResult> UpdateInvoice(Invoice invoice)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> DeleteInvoice(int invoiceId)
    {
        throw new NotImplementedException();
    }
}