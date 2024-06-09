using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forpost.Web.Contracts.SettingsBlock
{
    public class SettingsBlockRequest
    {
        public int SerialNumber { get; set; }
        public string Account { get; set; }
    }
}
