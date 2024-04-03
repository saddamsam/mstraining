using Policy_API.Models;

namespace Policy_API.Repository
{
    public interface IPolicyHolderRepo
    {
        Task<PolicyHolder> AddPolicyHolder(PolicyHolder policy);
        Task<PolicyHolder> UpdatePolicyHolder(string adharCardNo,string email,long Mobile);
        Task<bool> DeletePolicyHolder(string adharCardNo);
        Task<PolicyHolder> GetPolicyHolderById(string adharCardNo);
        Task<IEnumerable<PolicyHolder>> GetAllPolicyHolders();
    }
}
