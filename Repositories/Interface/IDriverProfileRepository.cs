using RideHailingAPI.Domain.Entities;

namespace RideHailingAPI.Repositories.Interface;

public interface IDriverProfileRepository
{
    public Task<DriverProfile?> GetDriverProfileByUserIdAsync(int userId); 
    public Task<DriverProfile?> GetDriverProfileByLicenseNumberAsync(string licenseNumber);
    public Task<IEnumerable<DriverProfile>> GetAvailableDriversAsync();
    public Task AddDriverProfileAsync(DriverProfile profile);
    public Task UpdateDriverProfileAsync(DriverProfile profile);
}