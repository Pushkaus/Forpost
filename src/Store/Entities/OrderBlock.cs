namespace Forpost.Store.Entities;

public class OrderBlock
{
    public int Id { get; set; } 
    
    public string? Klient { get; set; }
    public string? Account { get; set; }
    public string? Block { get; set; }

    public string? Amount {  get; set; }
    public string? SettingOption { get; set; }

    public DateOnly? Deadline { get; set; }
    public DateOnly? StartTask { get; set; }

    public DateOnly? EndTask { get; set; }
    public DateOnly? StartSetting { get; set; }

    public DateOnly? EndSetting { get; set; }
    public DateOnly? StartProgon { get; set; }

    public DateOnly? EndProgon { get; set; }

    public string? Status { get; set; }

    public string? SheetName { get; set;}

}