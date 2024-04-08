using ClaimAPI.Models;
using System.Net;

namespace ClaimAPI.Repository
{
    public interface IDriverAddressRepo
    {
        Task<DriverAddress> AddDriverAddress(DriverAddress address, string DL_NO);
        Task<DriverAddress> UpdateDriverAddress(DriverAddress address, string DL_NO, string oldDoorNo, string oldStreetName);
        Task<bool> DeleteDriverAddress(string DL_NO, string doorNo, string StreetName);
        Task<DriverAddress> GetDriverAddressByAddressId(string DL_NO, string doorNo, string StreetName);
        Task<IEnumerable<DriverAddress>> GetAllDriverAddress();
    }
}
