using Microsoft.EntityFrameworkCore;
using Policy_API.Context;
using Policy_API.Models;
using VaultSharp.V1.SystemBackend;

namespace Policy_API.Repository
{
    public class VehicleRepo : IVehicleRepo
    {

        private PolicyContext _dbContext;

        public VehicleRepo(PolicyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Vehicle> AddVehicle(Vehicle vehicle)
        {
            var result = await this._dbContext.Vehicles.AddAsync(vehicle);
            await this._dbContext.SaveChangesAsync();
            return result.Entity;
        }

        private async Task<Vehicle> FetchVehcile(string Registration_No)
        {
            return await this._dbContext.Vehicles.FirstOrDefaultAsync(p => p.RegistrationNo == Registration_No);
        }

        public async Task<bool> DeleteVehicle(string Registration_No)
        {
            bool status = false;

            var result = await FetchVehcile(Registration_No);

            if (result != null)
            {
                this._dbContext.Vehicles.Remove(result);
                this._dbContext.SaveChanges();
            }

            result = await FetchVehcile(Registration_No);

            if (result == null)
            {
                status = true;

            }


            return status;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            return await this._dbContext.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByRegNo(string Registration_No)
        {
            return await FetchVehcile(Registration_No);
        }

     
    }
}
