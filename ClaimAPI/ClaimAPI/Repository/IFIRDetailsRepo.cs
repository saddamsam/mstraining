using ClaimAPI.Models;

namespace ClaimAPI.Repository
{
    public interface IFIRDetailsRepo
    {
        Task<FIRDetails> AddFIRDetails(FIRDetails fIRDetails);
        Task<bool> DeleteFIRDetails(string FIRNO);
        Task<FIRDetails> GetFIRDetailsByFIRNO(string FIRNO);
        Task<IEnumerable<FIRDetails>> GetAllFIRDetails();

    }
}
