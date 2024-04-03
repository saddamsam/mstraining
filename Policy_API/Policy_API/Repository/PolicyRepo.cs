using Microsoft.EntityFrameworkCore;
using Policy_API.Context;
using Policy_API.Models;

namespace Policy_API.Repository
{
    public class PolicyRepo : IPolicyRepo
    {

        private PolicyContext _dbContext;


        public PolicyRepo(PolicyContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Policy> AddPolicy(Policy policy,string adharCardNo, string Registration_No)
        {

            PolicyHolder holder = await FetchPolicyHolder(adharCardNo);
            Vehicle vehicle = await FetchVehcile(Registration_No);

            policy.PolicyHolder = holder;
            policy.Vehicle = vehicle;

            var result = await this._dbContext.Policies.AddAsync(policy);
            await this._dbContext.SaveChangesAsync();
            return result.Entity;
        }

        private async Task<Policy> FetchPolicy(long PolicyNo)
        {
            return await this._dbContext.Policies.FirstOrDefaultAsync(p => p.PolicyNo == PolicyNo);
        }

        private async Task<PolicyHolder> FetchPolicyHolder(string adharCardNo)
        {
            return await this._dbContext.PolicyHolders.FirstOrDefaultAsync(p => p.AadharCardNo == adharCardNo);
        }

        private async Task<Vehicle> FetchVehcile(string Registration_No)
        {
            return await this._dbContext.Vehicles.FirstOrDefaultAsync(p => p.RegistrationNo == Registration_No);
        }



        public async Task<bool> DeletePolicy(long PolicyNo)
        {
            bool status = false;

            var result = await FetchPolicy(PolicyNo);

            if (result != null)
            {
                this._dbContext.Policies.Remove(result);
                this._dbContext.SaveChanges();
            }

            result = await FetchPolicy(PolicyNo);

            if(result == null)
            {
                status = true;

            }


            return status;
        }

        public async Task<IEnumerable<Policy>> GetAllPolicies()
        {

            return await this._dbContext.Policies
                .Include(p=>p.PolicyHolder)
                .Include(p=>p.Vehicle)
                .ToListAsync();
        }

        public async Task<Policy> GetPolicyByPolicyNo(long PolicyNo)
        {
           return await FetchPolicy(PolicyNo);
        }
    }
}
