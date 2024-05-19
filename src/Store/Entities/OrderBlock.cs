namespace Forpost.Store.Entities;

public class OrderBlock
{
    public int id { get; set; } 
    
    public string klient { get; set; }
    public string account { get; set; }
    public string block { get; set; }

    public string amount {  get; set; }
    public string setting_option { get; set; }

    public DateOnly deadline { get; set; }
    public DateOnly start_task { get; set; }

    public DateOnly end_task { get; set; }
    public DateOnly start_setting { get; set; }

    public DateOnly end_setting { get; set; }
    public DateOnly start_progon { get; set; }

    public DateOnly end_progon { get; set; }

    public string status { get; set; }

    public string sheet_name { get; set;}

}