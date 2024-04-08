using ClaimAPI.Models;

namespace ClaimAPI.Repository
{
    public interface IPolicyRepo
    {
        void AddPolicy(Policy policy);
    }
}
