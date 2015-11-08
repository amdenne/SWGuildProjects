using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace HRPortal.DLL
{
    public class TimeRepository : ITimeRepository
    {
        private string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "Time.json");

        public List<Time> GetAllTimes()
        {
            List<Time> Times = new List<Time>();

            string json = File.ReadAllText(FilePath);
            List<Time> data = JsonConvert.DeserializeObject<List<Time>>(json);

            return data;
        }

        public Time LoadTimes(int EmpId)
        {
            List<Time> time = GetAllTimes();
            return time.FirstOrDefault(a => a.EmpID == EmpId);
        }

        private void OverwriteFiles(List<Time> times)
        {
            foreach (var time in times)
            {
                File.WriteAllText(FilePath, JsonConvert.SerializeObject(times));
            }
        }

    public void CreateTime(Time newTime)
        {
            var times = GetAllTimes();
            times.Add(newTime);

            OverwriteFiles(times);
        }

        public void UpdateTime(Time TimeToUpdate)
        {
            var times = GetAllTimes();

            var existingTime = times.FirstOrDefault(a => a.FirstName == TimeToUpdate.FirstName && a.LastName == TimeToUpdate.LastName);
            existingTime.EmpID = TimeToUpdate.EmpID;
            existingTime.FirstName = TimeToUpdate.FirstName;
            existingTime.LastName = TimeToUpdate.LastName;
            existingTime.Date = TimeToUpdate.Date;
            existingTime.HoursWorked =+ TimeToUpdate.HoursWorked;
     
            OverwriteFiles(times);
        }

        public void Logger(Exception ex)
        {
            using (var writer = File.CreateText(@"HRPortal\DataFiles\Log.txt"))
            {
                writer.WriteLine("{0}", DateTime.Now.ToString("MM/dd/yyyy"));
                writer.WriteLine("{0}", ex.ToString());
            }
        }
    }
}
