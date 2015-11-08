using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HRPortal.DLL
{
    public interface IApplicationRepository
    {
        void CreateApplication(Application newApplication);
        List<Application> GetAllApplications();
        Application LoadApplication(int AppID);
        void UpdateApplication(Application applicationToUpdate);

    }
}
