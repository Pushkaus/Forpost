using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forpost.Web.Contracts.SettingsBlock
{
    public class SettingsBlockResponse
    {
        public SettingsBlockResponse() { } // Добавляем конструктор по умолчанию без аргументов

        public string? Block { get; set; }

        public string? SettingOption { get; set; }

        public string? Note { get; set; }

        public string? NumberInOrder { get; set; }

        public int SerialNumber { get; set; }

        public string? NumberRm { get; set; }

        public string? NumberNs { get; set; }

        public string? MessageJob { get; set; }

        public string? MessageRmOs { get; set; }

        public string? Memory { get; set; }

        public DateOnly? DateSetting { get; set; }

        public int? IdOrderBlocksInSetup { get; set; }

        public int? IdOrderProgon { get; set; }

        public DateTime? LastDate { get; set; }

        public string? LastUser { get; set; }

        public string? Store { get; set; }

        public bool? SettingFlag { get; set; }
    }
}
