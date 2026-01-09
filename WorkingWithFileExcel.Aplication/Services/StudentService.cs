using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithFileExcel.Domain.Models;
using WorkingWithFileExcel.Infrastucture.Data;

namespace WorkingWithFileExcel.Aplication.Services
{
    public class StudentService
    {
        private readonly ExcelContext context;
        private readonly List<ExternalAttendance> students;

        public StudentService()
        {
           
            this.context = new ExcelContext();
            this.students = context.GetExternalAttendances();
        }


       
           public List<ExternalAttendance> GetByCode(string code)
        {
            return students .Where(s =>
                {
                    var parts = s.FullNameWithCode.Split(' ');
                    var studentCode = parts.Length > 0 ? parts[^1] : "";
                    return studentCode.Equals(code, StringComparison.OrdinalIgnoreCase);
                })
                .ToList();
        }

        

        public bool DeleteById(string code)
        {
            var student = context.GetExternalAttendances().FirstOrDefault(x => x.FullNameWithCode.Contains(code, StringComparison.OrdinalIgnoreCase));
            if (student != null)
            {
                context.GetExternalAttendances().Remove(student);
                return true;
            }
            return false;
        }




        public void AddStudent(ExternalAttendance student)
        {
            context.AddExternalAttendance(student);
        }


    }

}
