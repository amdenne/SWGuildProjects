using System.Collections.Generic;
using HRPortal.Models;

namespace HRPortal.DLL
{
    public interface IPolicyRepository
    {
        void CreatePolicy(Policy newPolicy);
        List<Policy> GetAllPolicies(Policy p);
        Policy LoadPolicies(Policy p);
        void DeletePolicy(Policy PolicyToDelete);
        Policy GetPolicy(Policy p);
    }
}