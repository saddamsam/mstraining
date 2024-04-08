using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Policy_API.DTO;
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
    public class AddressesController : ControllerBase
    {
        private IAddressRepo _addressRepo;

        public AddressesController(IAddressRepo addressRepo)
        {
            _addressRepo = addressRepo;
        }


        [HttpGet]
        public async Task<IEnumerable<Address>> GetAllAddresses()
        {
            return await _addressRepo.GetAllAddress();
        }


        [HttpPut]
        //public async Task<Address> GetAddress(string aadharCardNo,[FromBody] string doorNo, string streetName)
        public async Task<Address> GetAddress([FromBody] AddressReq req)
        {
            return await _addressRepo.GetAddressByAddressId(req.aadharCardNo, req.doorNo, req.streetName);
        }



        [HttpPost("{aadharCardNo}")]
        public async Task<IActionResult> Post([FromBody] Address address, string aadharCardNo)
        {
            var result = await _addressRepo.AddAddress(address, aadharCardNo);

            return CreatedAtAction("GetAllAddresses", new { id = address.AddressId }, address);
        }

        [HttpPut("{aadharCardNo}/{oldDoorNo}/{oldStreetNo}")]
        public async Task<IActionResult> Put([FromBody] Address address, string aadharCardNo, string oldDoorNo, string oldStreetNo)
        {
            var result = await _addressRepo.UpdateAddress(address, aadharCardNo, oldDoorNo, oldStreetNo);

            return CreatedAtAction("GetAllAddresses", new { id = address.AddressId }, address);
        }


        [HttpDelete("{aadharCardNo}/{doorNo}/{streetNo}")]
        public async Task<IActionResult> Delete(string aadharCardNo, string doorNo, string streetNo)
        {
            var result = await _addressRepo.DeleteAddress(aadharCardNo, doorNo, streetNo);

            if (result == true)
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
