using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithFileExcel.Domain.Models;
using WorkingWithFileExcel.Infrastucture.Data;

namespace WorkingWithFileExcel.Aplication.Services
{
    public class ExternalAttendanceService
    {
        private readonly ExcelContext context;

        public ExternalAttendanceService(ExcelContext context)
        {
            this.context = context;
        }

        public List<ExternalAttendance> GetAll() => context.GetExternalAttendances();

        public ExternalAttendance GetByName(string name)
        {
            return context.GetExternalAttendances()
                .FirstOrDefault(x => x.FullNameWithCode.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public ExternalAttendance GetByEmail(string email)
        {
            return context.GetExternalAttendances()
                .FirstOrDefault(x => x.Email.Contains(email, StringComparison.OrdinalIgnoreCase));
        }

        public List<ExternalAttendance> GetGuests()
        {
            return context.GetExternalAttendances().Where(x => x.IsHost == "Ha").ToList();
        }

        public List<ExternalAttendance> GetWaitingRoom()
        {
            return context.GetExternalAttendances().Where(x => x.IsWaiting == "Ha").ToList();
        }

        public int GetCount()
        {
            return context.GetExternalAttendances().Count();
        }

        public List<ExternalAttendance> GetMostActive()
        {
            return context.GetExternalAttendances()
                .OrderByDescending(x => x.Duration)
                .Take(5)
                .ToList();
        }




    }
}
