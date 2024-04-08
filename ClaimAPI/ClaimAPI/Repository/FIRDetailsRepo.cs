using ClaimAPI.Context;
using ClaimAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClaimAPI.Repository
{
    public class FIRDetailsRepo : IFIRDetailsRepo
    {
        private readonly ClaimContext _dbContext;

        public FIRDetailsRepo(ClaimContext claimContext)
        {
            _dbContext = claimContext;
        }

        public async Task<FIRDetails> AddFIRDetails(FIRDetails fIRDetails)
        {
            

            var result = await this._dbContext.FIRDetails.AddAsync(fIRDetails);
            await this._dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteFIRDetails(string FIRNO)
        {
            bool status = false;

            var result = await FIRDetails(FIRNO);

            if (result != null)
            {
                this._dbContext.FIRDetails.Remove(result);
                this._dbContext.SaveChanges();
            }

            result = await FIRDetails(FIRNO);

            if (result == null)
            {
                status = true;

            }


            return status;
        }

        private async Task<FIRDetails> FIRDetails(string FIRNO)
        {
            return await this._dbContext.FIRDetails.FirstOrDefaultAsync(a => a.FIRNO == FIRNO);
        }


        public async Task<IEnumerable<FIRDetails>> GetAllFIRDetails()
        {
            return await this._dbContext.FIRDetails.ToListAsync();
        }

        public async Task<FIRDetails> GetFIRDetailsByFIRNO(string FIRNO)
        {
            return await this._dbContext.FIRDetails.FirstOrDefaultAsync(a => a.FIRNO == FIRNO);
        }
    }
}
