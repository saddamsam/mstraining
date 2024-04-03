using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Policy_API.Models;
using Policy_API.Repository;

namespace Policy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private IPolicyRepo _policyRepo { get; set; }

        public PoliciesController(IPolicyRepo policyRepo)
        {
            _policyRepo = policyRepo;
        }


        [HttpGet]
        public async Task<IEnumerable<Policy>> GetAllPolicies()
        {
            return await this._policyRepo.GetAllPolicies();
        }

        [HttpGet("{adharCardNo}")]
        public async Task<Policy> GetPolicy(long policyNo)
        {
            return await this._policyRepo.GetPolicyByPolicyNo(policyNo);
        }


        [HttpPost("{aadharCardNo}/{registrationNo}")]
        public async Task<IActionResult> Post([FromBody] Policy policy, string aadharCardNo, string registrationNo)
        {
            await this._policyRepo.AddPolicy(policy, aadharCardNo, registrationNo);

            return CreatedAtAction("GetAllPolicies", new { id = policy.PolicyNo }, policy);
        }

        [HttpDelete("{policyNo}")]
        public async Task<IActionResult> Delete(long policyNo)
        {
            if (await this._policyRepo.DeletePolicy(policyNo))
            {
                return new OkResult();
            }
            else
            {
                return new BadRequestResult();
            }
        }
    }
}
