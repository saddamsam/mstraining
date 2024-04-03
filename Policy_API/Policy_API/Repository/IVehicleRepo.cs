using Policy_API.Models;

namespace Policy_API.Repository
{
    public interface IVehicleRepo
    {

        Task<Vehicle> AddVehicle(Vehicle vehicle);
       Task<bool> DeleteVehicle(string Registration_No);
        Task<Vehicle> GetVehicleByRegNo(string Registration_No);
        Task<IEnumerable<Vehicle>> GetAllVehicles();
    }
}
