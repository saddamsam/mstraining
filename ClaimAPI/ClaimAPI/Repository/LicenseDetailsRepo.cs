using ClaimAPI.Context;
using ClaimAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ClaimAPI.Repository
{
    public class LicenseDetailsRepo : ILicenseDetailsRepo
    {

        private readonly ClaimContext _dbContext;


        public LicenseDetailsRepo(ClaimContext claimContext)
        {
            _dbContext = claimContext;
        }

        public async Task<LicenseDetails> AddDriverAddress(LicenseDetails licenseDetails)
        {

            var result = await this._dbContext.LicenseDetails.AddAsync(licenseDetails);
            await this._dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteDriverAddress(string DL_NO)
        {
            bool status = false;

            var result = await FetchLicenseDetails(DL_NO);

            if (result != null)
            {
                this._dbContext.LicenseDetails.Remove(result);
                this._dbContext.SaveChanges();
            }

            result = await FetchLicenseDetails(DL_NO);

            if (result == null)
            {
                status = true;

            }


            return status;
        }

        private async Task<LicenseDetails> FetchLicenseDetails(string DL_NO)
        {
            return await this._dbContext.LicenseDetails.FirstOrDefaultAsync(a => a.DLNO == DL_NO );
        }


        public async Task<IEnumerable<LicenseDetails>> GetAllLicenseDetails()
        {
            return await this._dbContext.LicenseDetails.ToListAsync();
        }

        public async Task<LicenseDetails> GetLicenseByDL(string DL_NO)
        {
            return await this._dbContext.LicenseDetails.FirstOrDefaultAsync(a => a.DLNO == DL_NO);
        }
    }
}
