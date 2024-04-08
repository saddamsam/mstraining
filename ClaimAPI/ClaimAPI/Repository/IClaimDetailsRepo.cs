using ClaimAPI.Models;

namespace ClaimAPI.Repository
{
    public interface IClaimDetailsRepo
    {
        Task<ClaimDetails> AddClaimDetails(ClaimDetails claimDetails);
        Task<bool> DeleteClaimDetails(long PolicyNo);
        Task<ClaimDetails> GetClaimByPolicyNO(long PolicyNo);
        Task<IEnumerable<ClaimDetails>> GetAllClaimDetails();

    }
}
