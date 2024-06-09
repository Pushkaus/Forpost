namespace Forpost.Store.Entities;

public class OrderBlock
{
    public int Id { get; set; } 
    
    public string? Klient { get; set; }
    public string? Account { get; set; }
    public string? Block { get; set; }

    public string? Amount {  get; set; }
    public string? SettingOption { get; set; }

    public DateTime? Deadline { get; set; }
    public DateTime? StartTask { get; set; }

    public DateTime? EndTask { get; set; }
    public DateTime? StartSetting { get; set; }

    public DateTime? EndSetting { get; set; }
    public DateTime? StartProgon { get; set; }

    public DateTime? EndProgon { get; set; }

    public string? Status { get; set; }

    public string? SheetName { get; set;}

}