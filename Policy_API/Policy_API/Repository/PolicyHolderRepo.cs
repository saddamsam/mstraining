using Microsoft.EntityFrameworkCore;
using Policy_API.Context;
using Policy_API.Models;

namespace Policy_API.Repository
{
    public class PolicyHolderRepo : IPolicyHolderRepo
    {
        private PolicyContext _dbContext;


        public PolicyHolderRepo(PolicyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PolicyHolder> AddPolicyHolder(PolicyHolder policy)
        {
            var result = await this._dbContext.PolicyHolders.AddAsync(policy); 

            await this._dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> DeletePolicyHolder(string adharCardNo)
        {
            bool status = false;
            PolicyHolder result = await FetchPolicyHolder(adharCardNo);

            if (result != null)
            {
                this._dbContext.PolicyHolders.Remove(result);
                this._dbContext.SaveChanges();


            }

            result = await FetchPolicyHolder(adharCardNo);


            if (result == null)
            {
                status = true;

            }



            return status;

        }

        private async Task<PolicyHolder> FetchPolicyHolder(string adharCardNo)
        {
            return await this._dbContext.PolicyHolders.FirstOrDefaultAsync(p => p.AadharCardNo == adharCardNo);
        }

        public async Task<IEnumerable<PolicyHolder>> GetAllPolicyHolders()
        {
            return await this._dbContext.PolicyHolders.ToListAsync();
        }

        public async Task<PolicyHolder> GetPolicyHolderById(string adharCardNo)
        {
            return await FetchPolicyHolder(adharCardNo);
        }

        public async Task<PolicyHolder> UpdatePolicyHolder(string adharCardNo, string email, long Mobile)
        {
           var result = await FetchPolicyHolder(adharCardNo);

            if(result != null)
            {
                result.Email = email;
                result.MobileNo = Mobile;
                this._dbContext.SaveChanges();
            }

            return result;
        }
    }
}
