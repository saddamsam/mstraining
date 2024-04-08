using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Policy_API.Repository;
using System.Text.Json;

namespace Policy_API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiversion}/[controller]")]
    [EnableCors]
    [ApiController]
    public class PolicyPublishController : ControllerBase
    {

        private IPolicyPublishRepo _policyPublishRepo;
            private IPolicyRepo _policyRepo;
            private IConfiguration _configuration;

        public PolicyPublishController(IPolicyPublishRepo policyPublishRepo, IPolicyRepo policyRepo, IConfiguration configuration) { 
        
            _configuration = configuration;
            _policyPublishRepo = policyPublishRepo;
            _policyRepo = policyRepo;
        }

        [HttpGet]
        [Route("Publish")]
        public async Task<IActionResult> PolicyPublish()
        {
            string topicName = _configuration["TopicName"];

            var data = await _policyRepo.GetAllPolicies();

            string message = JsonSerializer.Serialize(data);

           var response= await _policyPublishRepo.PublishPolicyData(topicName, message, _configuration);

            return Ok(response);
        }


    }
}
