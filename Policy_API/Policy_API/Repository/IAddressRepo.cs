using Policy_API.Models;

namespace Policy_API.Repository
{
    public interface IAddressRepo
    {
        Task<Address> AddAddress(Address address, string adharCardNo);
        Task<Address> UpdateAddress(Address address,string adharCardNo, string oldDoorNo, string oldStreetName);
        Task<bool> DeleteAddress(string adharCardNo,string doorNo,string StreetName);
        Task<Address> GetAddressByAddressId(string adharCardNo, string doorNo, string StreetName);
        Task<IEnumerable<Address>> GetAllAddress();
    }
}
