using ClaimAPI.Context;
using ClaimAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ClaimAPI.Repository
{
    public class DriverAddressRepo : IDriverAddressRepo
    {

        private readonly ClaimContext _dbContext;

        public DriverAddressRepo(ClaimContext claimContext) {
            _dbContext = claimContext;
        }

        public async Task<DriverAddress> AddDriverAddress(DriverAddress address, string DL_NO)
        {
            LicenseDetails licenseDetails = await LicenseDetails(DL_NO);

            address.LicenseDetails = licenseDetails;

            var result = await this._dbContext.DriverAddresses.AddAsync(address);
            await this._dbContext.SaveChangesAsync();
            return result.Entity;
        }

        private async Task<DriverAddress> FetchDriverAddress(string DL_NO, string doorNo, string StreetName)
        {
            return await this._dbContext.DriverAddresses.FirstOrDefaultAsync(a => a.DLNO == DL_NO && a.DoorNo == doorNo && a.streetName == StreetName);
        }




        private async Task<LicenseDetails> LicenseDetails(string DL_NO)
        {
            return await this._dbContext.LicenseDetails.FirstOrDefaultAsync(a => a.DLNO == DL_NO );
        }


        public async Task<bool> DeleteDriverAddress(string DL_NO, string doorNo, string StreetName)
        {
            bool status = false;

            var result = await FetchDriverAddress(DL_NO, doorNo, StreetName);

            if (result != null)
            {
                this._dbContext.DriverAddresses.Remove(result);
                this._dbContext.SaveChanges();
            }

            result = await FetchDriverAddress(DL_NO, doorNo, StreetName);

            if (result == null)
            {
                status = true;

            }


            return status;
        }

        public async Task<IEnumerable<DriverAddress>> GetAllDriverAddress()
        {
            return await this._dbContext.DriverAddresses.ToListAsync();
        }

        public async Task<DriverAddress> GetDriverAddressByAddressId(string DL_NO, string doorNo, string StreetName)
        {
            return await this._dbContext.DriverAddresses.FirstOrDefaultAsync(a => a.DLNO == DL_NO && a.DoorNo == doorNo && a.streetName == StreetName);
        }

        public async Task<DriverAddress> UpdateDriverAddress(DriverAddress address, string DL_NO, string oldDoorNo, string oldStreetName)
        {
            var result = await FetchDriverAddress(DL_NO, oldDoorNo, oldStreetName);

            if (result != null)
            {
                result.DoorNo = address.DoorNo;
                result.streetName = address.streetName;
                result.City = address.City;
                result.Country = address.Country;
                result.Pincode = address.Pincode;
                this._dbContext.SaveChanges();
            }

            return result;
        }
    }
}
