using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Policy_API.Models;
using Policy_API.Repository;

namespace Policy_API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiversion}/[controller]")]
    [EnableCors]
    [ApiController]
    public class PolicyHoldersController : ControllerBase
    {
        private IPolicyHolderRepo _policyHolderRepo { get; set; }

        public PolicyHoldersController(IPolicyHolderRepo policyHolderRepo)
        {
                
            _policyHolderRepo = policyHolderRepo;
        }


        [HttpGet]
        public async Task<IEnumerable<PolicyHolder>> Get()
        {
            return await this._policyHolderRepo.GetAllPolicyHolders();
        }

        [HttpGet("{adharCardNo}")]
        public async Task<PolicyHolder> Get(string adharCardNo)
        {
            return await this._policyHolderRepo.GetPolicyHolderById(adharCardNo);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PolicyHolder policyHolder)
        {
            await this._policyHolderRepo.AddPolicyHolder(policyHolder);

            return CreatedAtAction(nameof(Get),new { id = policyHolder.AadharCardNo}, policyHolder);
        }

        [HttpPut("{adharCardNo}/{Email}/{Mobile}")]
        public async Task<IActionResult> Put(string adharCardNo,string Email,long Mobile)
        {
            var result = await this._policyHolderRepo.UpdatePolicyHolder(adharCardNo,Email,Mobile);

            return CreatedAtAction(nameof(Get), new { id = result.AadharCardNo }, result);
        }


        [HttpDelete("{adharCardNo}")]
        public async Task<IActionResult> Delete(string adharCardNo)
        {
            if( await this._policyHolderRepo.DeletePolicyHolder(adharCardNo))
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
