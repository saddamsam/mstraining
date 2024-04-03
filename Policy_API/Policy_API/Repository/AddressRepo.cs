using Microsoft.EntityFrameworkCore;
using Policy_API.Context;
using Policy_API.Models;
using System.Reflection;

namespace Policy_API.Repository
{
    public class AddressRepo : IAddressRepo
    {

        private PolicyContext _dbContext;

        public AddressRepo(PolicyContext dbContext)
        {
                _dbContext = dbContext;
        }

        private async Task<Address> FetchAddress(string adharCardNo, string doorNo, string StreetName)
        {
            return await this._dbContext.Addresses.FirstOrDefaultAsync(a=>a.AdharCardNo==adharCardNo && a.DoorNo==doorNo && a.streetName == StreetName);
        }

        private async Task<PolicyHolder> FetchPolicyHolder(string adharCardNo)
        {
            return await this._dbContext.PolicyHolders.FirstOrDefaultAsync(p => p.AadharCardNo == adharCardNo);
        }

        public async Task<Address> AddAddress(Address address, string adharCardNo)
        {
            PolicyHolder policyHolder = await FetchPolicyHolder(adharCardNo);

            address.PolicyHolder = policyHolder;

            var result = await this._dbContext.Addresses.AddAsync(address);
            await this._dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAddress(string adharCardNo, string doorNo, string StreetName)
        {
            bool status = false;

            var result = await FetchAddress(adharCardNo, doorNo, StreetName);

            if (result != null)
            {
                this._dbContext.Addresses.Remove(result);
                this._dbContext.SaveChanges();
            }

            result = await FetchAddress(adharCardNo, doorNo, StreetName);

            if (result == null)
            {
                status = true;

            }


            return status;
        }

        public async Task<Address> GetAddressByAddressId(string adharCardNo, string doorNo, string StreetName)
        {
            return await FetchAddress(adharCardNo, doorNo, StreetName);
        }

        public async Task<IEnumerable<Address>> GetAllAddress()
        {
            return await this._dbContext.Addresses.ToListAsync();

        }

        public async Task<Address> UpdateAddress(Address address, string adharCardNo, string oldDoorNo, string oldStreetName)
        {
            var result = await FetchAddress(adharCardNo, oldDoorNo, oldStreetName);

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
