using System.Collections.Generic;
using HRPortal.Models;

namespace HRPortal.DLL
{
    public interface ITimeRepository
    {
        void CreateTime(Time newTime);
        List<Time> GetAllTimes();
        Time LoadTimes(int EmpId);
        void UpdateTime(Time TimeToUpdate);
    }
}