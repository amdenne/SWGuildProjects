using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;
using System.IO;

namespace HRPortal.DLL
{
    public class ApplicationRepository : IApplicationRepository
    {
        private string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "Application.txt");

        public List<Application> GetAllApplications()
        {
            List<Application> applications = new List<Application>();

            var reader = File.ReadAllLines(FilePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var application = new Application();

                application.FirstName = columns[0];
                application.LastName = columns[1];
                application.AppID = int.Parse(columns[2]);
                application.Address = columns[3];
                application.PhoneNumber = columns[4];
                application.City = columns[5];
                application.State = columns[6];
                application.Zip = columns[7];
                application.JobHistory = columns[8];

                applications.Add(application);
            }

            return applications;
        }

        public Application LoadApplication(int AppID)
        {
            List<Application> application = GetAllApplications();
            return application.FirstOrDefault(a => a.AppID == AppID);
        }

        public void UpdateApplication(Application applicationToUpdate)
        {
            var applications = GetAllApplications();

            var existingApplication = applications
                .FirstOrDefault(a => a.AppID == applicationToUpdate.AppID);
            existingApplication.FirstName = applicationToUpdate.FirstName;
            existingApplication.LastName = applicationToUpdate.LastName;
            existingApplication.AppID = applicationToUpdate.AppID;
            existingApplication.Address = applicationToUpdate.Address;
            existingApplication.PhoneNumber = applicationToUpdate.PhoneNumber;
            existingApplication.City = applicationToUpdate.City;
            existingApplication.State = applicationToUpdate.State;
            existingApplication.Zip = applicationToUpdate.Zip;
            existingApplication.JobHistory = applicationToUpdate.JobHistory;
        }

        private void OverwriteFiles(List<Application> applications)
        {
            File.Delete(FilePath);

            using (var writer = File.CreateText(FilePath))
            {
                writer.WriteLine("FirstName,LastName,AppID,Address,PhoneNumber,City,State,Zip,JobHistory");

                foreach(var application in applications)
                {
                    writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", application.FirstName, application.LastName,
                        application.AppID, application.Address, application.PhoneNumber, application.City, application.State,
                        application.Zip, application.JobHistory);

                }
            }
        }

        public void CreateApplication(Application newApplication)
        {
            var applications = GetAllApplications();
            applications.Add(newApplication);

            OverwriteFiles(applications);
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
