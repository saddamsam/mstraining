using ClaimAPI.Context;
using ClaimAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ClaimAPI.Repository
{
    public class DriverDetailsRepo : IDriverDetailsRepo
    {

        private readonly ClaimContext _dbContext;

        public DriverDetailsRepo(ClaimContext claimContext)
        {
            _dbContext = claimContext;
        }

        public async Task<DriverDetails> AddDriverDetails(DriverDetails driverDetails, string DL_NO)
        {
            LicenseDetails licenseDetails = await LicenseDetails(DL_NO);

            driverDetails.LicenseDetails = licenseDetails;

            var result = await this._dbContext.DriverDetails.AddAsync(driverDetails);
            await this._dbContext.SaveChangesAsync();
            return result.Entity;
        }

        private async Task<LicenseDetails> LicenseDetails(string DL_NO)
        {
            return await this._dbContext.LicenseDetails.FirstOrDefaultAsync(a => a.DLNO == DL_NO);
        }

        private async Task<DriverDetails> DriverDetails(string DL_NO)
        {
            return await this._dbContext.DriverDetails.FirstOrDefaultAsync(a => a.DLNO == DL_NO);
        }


        public async Task<bool> DeleteDriverDetails(string DL_NO)
        {
            bool status = false;

            var result = await DriverDetails(DL_NO);

            if (result != null)
            {
                this._dbContext.DriverDetails.Remove(result);
                this._dbContext.SaveChanges();
            }

            result = await DriverDetails(DL_NO);

            if (result == null)
            {
                status = true;

            }


            return status;
        }

        public async Task<IEnumerable<DriverDetails>> GetAllDriverDetails()
        {
            return await this._dbContext.DriverDetails.ToListAsync();
        }

        public async Task<DriverDetails> GetDriverDetailsByDL(string DL_NO)
        {
            return await this._dbContext.DriverDetails.FirstOrDefaultAsync(a => a.DLNO == DL_NO);
        }
    }
}
