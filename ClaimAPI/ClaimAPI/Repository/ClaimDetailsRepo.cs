using ClaimAPI.Context;
using ClaimAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClaimAPI.Repository
{
    public class ClaimDetailsRepo : IClaimDetailsRepo
    {
        private readonly ClaimContext _dbContext;

        public ClaimDetailsRepo(ClaimContext claimContext)
        {
            _dbContext = claimContext;
        }

        public async Task<ClaimDetails> AddClaimDetails(ClaimDetails claimDetails)
        {
           
            var result = await this._dbContext.ClaimDetails.AddAsync(claimDetails);
            await this._dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteClaimDetails(long PolicyNo)
        {
            bool status = false;

            var result = await ClaimDetails(PolicyNo);

            if (result != null)
            {
                this._dbContext.ClaimDetails.Remove(result);
                this._dbContext.SaveChanges();
            }

            result = await ClaimDetails(PolicyNo);

            if (result == null)
            {
                status = true;

            }


            return status;
        }

        private async Task<ClaimDetails> ClaimDetails(long PolicyNo)
        {
            return await this._dbContext.ClaimDetails.FirstOrDefaultAsync(a => a.PolicyNo == PolicyNo);
        }


        public async Task<IEnumerable<ClaimDetails>> GetAllClaimDetails()
        {
            return await this._dbContext.ClaimDetails.ToListAsync();
        }

        public async Task<ClaimDetails> GetClaimByPolicyNO(long PolicyNo)
        {
            return await this._dbContext.ClaimDetails.FirstOrDefaultAsync(a => a.PolicyNo == PolicyNo);
        }
    }
}
