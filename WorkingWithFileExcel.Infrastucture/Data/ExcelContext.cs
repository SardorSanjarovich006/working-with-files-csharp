using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WorkingWithFileExcel.Domain.Models;

namespace WorkingWithFileExcel.Infrastucture.Data
{
    public class ExcelContext
    {
        List<ExternalAttendance> externalAttendances = new List<ExternalAttendance>();
        private readonly string directoryPath;

        private readonly string filePath;
        public ExcelContext()
        {
            string directoryPath = @"C:\Users\Asus\Desktop\Attendance";
            filePath = Path.Combine(directoryPath, "attendance4.csv"); 

            string[] excelLines = File.ReadAllLines(filePath);

            foreach (var line in excelLines.Skip(1))
            {
                string[] data= line.Split(',');

                if (data.Length <7 ) 
                    continue;

                ExternalAttendance  exat=new ExternalAttendance
                {
                    FullNameWithCode = data[0],
                    Email = data[1],
                    EnterDate = data[2],
                    ExitDate = data[3],
                    Duration = int.Parse(data[4]),
                    IsHost = data[5],
                    IsWaiting = data[6]
                };

                externalAttendances.Add(exat);
            }
        }



        public void AddExternalAttendance(ExternalAttendance ea)
        {
            externalAttendances.Add(ea);

            string line = $"{ea.FullNameWithCode},{ea.Email},{ea.EnterDate},{ea.ExitDate},{ea.Duration},{ea.IsHost},{ea.IsWaiting}";

            File.AppendAllText(filePath, Environment.NewLine + line);
        }

        public List<ExternalAttendance> GetExternalAttendances()
        {
            return externalAttendances;
        }
    }

}
