using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Прием
{
    public class ProgramSettings
    {
        public static List<Settings> settings = new List<Settings>();
    }

    public class Settings
    {
        public string AssaServer { get; set; }
        public string AssaDataBase { get; set; }
        public string AssaLogin { get; set; }
        public string AssaPassword { get; set; }
        public string PtsServer { get; set; }
        public string PtsDataBase { get; set; }
        public string PtsLogin { get; set; }
        public string PtsPassword { get; set; }
        public int IsDeveloper { get; set; }
    }
}
