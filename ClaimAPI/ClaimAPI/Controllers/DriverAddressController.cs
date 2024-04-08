using ClaimAPI.DTO;
using ClaimAPI.Models;
using ClaimAPI.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClaimAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiversion}/[controller]")]
    [EnableCors]
    [ApiController]
    public class DriverAddressController : ControllerBase
    {
        private IDriverAddressRepo _addressRepo;

        public DriverAddressController(IDriverAddressRepo addressRepo)
        {
            _addressRepo = addressRepo;
        }


        [HttpGet]
        public async Task<IEnumerable<DriverAddress>> GetAllAddresses()
        {
            return await _addressRepo.GetAllDriverAddress();
        }


        [HttpPut]
        //public async Task<Address> GetAddress(string aadharCardNo,[FromBody] string doorNo, string streetName)
        public async Task<DriverAddress> GetAddress([FromBody] DriverAddressReq req)
        {
            return await _addressRepo.GetDriverAddressByAddressId(req.DLNO, req.DoorNo, req.streetName);
        }



        [HttpPost("{aadharCardNo}")]
        public async Task<IActionResult> Post([FromBody] DriverAddress address, string DLNO)
        {
            var result = await _addressRepo.AddDriverAddress(address, DLNO);

            return CreatedAtAction("GetAllAddresses", new { id = address.AddressId }, address);
        }

        [HttpPut("{DLNO}/{oldDoorNo}/{oldStreetNo}")]
        public async Task<IActionResult> Put([FromBody] DriverAddress address, string DLNO, string oldDoorNo, string oldStreetNo)
        {
            var result = await _addressRepo.UpdateDriverAddress(address, DLNO, oldDoorNo, oldStreetNo);

            return CreatedAtAction("GetAllAddresses", new { id = address.AddressId }, address);
        }


        [HttpDelete("{DLNO}/{doorNo}/{streetNo}")]
        public async Task<IActionResult> Delete(string DLNO, string doorNo, string streetNo)
        {
            var result = await _addressRepo.DeleteDriverAddress(DLNO, doorNo, streetNo);

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

