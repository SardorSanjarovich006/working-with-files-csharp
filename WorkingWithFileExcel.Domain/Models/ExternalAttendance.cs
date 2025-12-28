using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithFileExcel.Domain.Models
{
    public class ExternalAttendance
    {
        public string FullNameWithCode { get; set; }
        public string Email { get; set; }
        public string EnterDate { get; set; }
        public string ExitDate { get; set; }
        public int Duration { get; set; }
        public string IsHost { get; set; }
        public string IsWaiting { get; set; }
    }
}
