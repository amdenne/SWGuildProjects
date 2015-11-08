using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;
using System.IO;

namespace HRPortal.DLL
{
    public class PolicyRepository : IPolicyRepository
    {
        private string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles");

        public List<Policy> GetAllPolicies(Policy p)
        {
            List<Policy> policies = new List<Policy>();

            var reader = File.ReadAllLines(FilePath + @"\" + p.Category + ".txt");

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var policy = new Policy();

                policy.Category = columns[0];
                policy.PolicyTitle = columns[1];
                policy.PolicyDescription = columns[2];

                policies.Add(policy);
            }

            return policies;
        }
        public Policy GetPolicy(Policy p)
        {
            List<Policy> policy = GetAllPolicies(p);
            return policy.FirstOrDefault(x => x.PolicyTitle == p.PolicyTitle);
        }

        public Policy LoadPolicies(Policy p)
        {
            List<Policy> policy = GetAllPolicies(p);
            return policy.FirstOrDefault();
        }

        private void OverwriteFiles(List<Policy> policies, Policy p)
        {
            File.Delete(FilePath + @"\" + p.Category + ".txt");

            using (var writer = File.CreateText(FilePath + @"\" + p.Category + ".txt"))
            {
                writer.WriteLine("Policy Category, Policy Title, Policy Description");

                foreach (var policy in policies)
                {
                    writer.WriteLine("{0},{1},{2}", policy.Category, policy.PolicyTitle, policy.PolicyDescription);

                }
            }
        }

        public void CreatePolicy(Policy newPolicy)
        {
            var policies = GetAllPolicies(newPolicy);
            policies.Add(newPolicy);

            OverwriteFiles(policies, newPolicy);
        }

        public void DeletePolicy(Policy PolicyToDelete)
        {
            var policies = GetAllPolicies(PolicyToDelete);
            policies.RemoveAll(x => x.PolicyID == PolicyToDelete.PolicyID);

            OverwriteFiles(policies, PolicyToDelete);
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
