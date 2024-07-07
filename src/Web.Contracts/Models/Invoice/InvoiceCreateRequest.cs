namespace Forpost.Store.Repositories;

/// <summary>
/// Модель запроса на создание счета
/// </summary>
public class InvoiceCreateRequest
{
    public string Number { get; set; }
    public string Contragent { get; set; }
    public string? Description { get; set; }
}