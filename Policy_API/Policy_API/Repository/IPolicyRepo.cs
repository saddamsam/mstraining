using Policy_API.Models;

namespace Policy_API.Repository
{
    public interface IPolicyRepo
    {
        Task<Policy> AddPolicy(Policy policy,string adharCardNo,string Registration_No);
        Task<bool> DeletePolicy(long PolicyNo);
        Task<Policy> GetPolicyByPolicyNo(long PolicyNo);
        Task<IEnumerable<Policy>> GetAllPolicies();
    }
}
