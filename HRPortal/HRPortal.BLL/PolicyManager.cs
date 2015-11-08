using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.DLL;
using HRPortal.Models;

namespace HRPortal.BLL
{
    public class PolicyManager
    {
        private IPolicyRepository _repo;

        public PolicyManager()
        {
            _repo = new PolicyRepository();
        }

        public PolicyManager(IPolicyRepository repo)
        {
            _repo = repo;
        }

        public Response<List<Policy>> LoadAllPolicies(Policy p)
        {
            var response = new Response<List<Policy>>();

            try
            {
                response.Data = _repo.GetAllPolicies(p);
                response.Message = "Success";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        
        public Response<Policy> GetPolicies(Policy p)
        {
            var response = new Response<Policy>();

            try
            {
                var policy = _repo.LoadPolicies(p);

                if (policy == null)
                {
                    response.Success = false;
                    response.Message = "Policy was not found...";
                }
                else
                {
                    response.Success = true;
                    response.Data = policy;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Policy> CreatePolicy(Policy newPolicy)
        {
            var response = new Response<Policy>();

            try
            {
                var allPolicies = _repo.GetAllPolicies(newPolicy);

                int LatestPolicyNumber = allPolicies.Select(a => a.PolicyID).LastOrDefault();
                newPolicy.PolicyID = LatestPolicyNumber + 1;

                response.Data = new Policy();
                response.Data.Category = newPolicy.Category;
                response.Data.PolicyTitle = newPolicy.PolicyTitle;
                response.Data.PolicyDescription = newPolicy.PolicyDescription;
                response.Data.PolicyID = newPolicy.PolicyID;
            
                response.Success = true;
                _repo.CreatePolicy(newPolicy);
                response.Message = "Application was created.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Policy> DeletePolicy(Policy PolicyToDelete)
        {
            var response = new Response<Policy>();

            try
            {
                _repo.DeletePolicy(PolicyToDelete);

                response.Success = true;
                response.Message = "You have successfully deleted the policy";

            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

            }
            return response;
        }

        public Response<Policy> GetPolicy(Policy policy)
        {
            var response = new Response<Policy>();

            try
            {
                response.Data = _repo.GetPolicy(policy);   
                 
                response.Success = true;
                response.Message = "you have successfully gotten the policy.";                                           
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
            }
        }
    }



