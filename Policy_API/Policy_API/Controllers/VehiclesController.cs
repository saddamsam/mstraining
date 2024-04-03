using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Policy_API.Context;
using Policy_API.Models;
using Policy_API.Repository;

namespace Policy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepo _vehicleRepo;

        public VehiclesController(IVehicleRepo context)
        {
            _vehicleRepo = context;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await _vehicleRepo.GetAllVehicles();//.ToListAsync();
        }

        // GET: api/Vehicles/5
        [HttpGet("{registrationNo}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(string registrationNo)
        {
            var vehicle = await _vehicleRepo.GetVehicleByRegNo(registrationNo);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            await _vehicleRepo.AddVehicle(vehicle);
            

            return CreatedAtAction("GetVehicles", new { id = vehicle.RegistrationNo }, vehicle);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{registrationNo}")]
        public async Task<IActionResult> DeleteVehicle(string registrationNo)
        {
            var result = await _vehicleRepo.DeleteVehicle(registrationNo);
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
