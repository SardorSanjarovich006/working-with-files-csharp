using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithFileExcel.Domain.Models
{
    public class Student
    {
        public ExternalAttendance ExternalAttendance { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }

    }
}
