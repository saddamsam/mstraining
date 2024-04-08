using ClaimAPI.Models;

namespace ClaimAPI.Repository
{
    public interface ILicenseDetailsRepo
    {
        Task<LicenseDetails> AddDriverAddress(LicenseDetails licenseDetails);
        Task<bool> DeleteDriverAddress(string DL_NO);
        Task<LicenseDetails> GetLicenseByDL(string DL_NO);
        Task<IEnumerable<LicenseDetails>> GetAllLicenseDetails();

    }
}
