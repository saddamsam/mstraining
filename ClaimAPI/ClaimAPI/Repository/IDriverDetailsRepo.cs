using ClaimAPI.Models;

namespace ClaimAPI.Repository
{
    public interface IDriverDetailsRepo
    {
        Task<DriverDetails> AddDriverDetails(DriverDetails driverDetails,string DL_NO);
        Task<bool> DeleteDriverDetails(string DL_NO);
        Task<DriverDetails> GetDriverDetailsByDL(string DL_NO);
        Task<IEnumerable<DriverDetails>> GetAllDriverDetails();
    }
}
