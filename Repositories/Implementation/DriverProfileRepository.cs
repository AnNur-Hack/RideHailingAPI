using Microsoft.EntityFrameworkCore;
using RideHailingAPI.Data;
using RideHailingAPI.Domain.Entities;
using RideHailingAPI.Repositories.Interface;

namespace RideHailingAPI.Repositories.Implementation;

public class DriverProfileRepository(ApplicationDbContext context) : IDriverProfileRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<DriverProfile?> GetDriverProfileByUserIdAsync(int userId)
    {
        return await _context.DriverProfiles.FirstOrDefaultAsync(d => d.UserId == userId);
    }

    public async Task<DriverProfile?> GetDriverProfileByLicenseNumberAsync(string licenseNumber)
    {
        return await _context.DriverProfiles.FirstOrDefaultAsync(d => d.LicenseNumber == licenseNumber);
    }

    public async Task<IEnumerable<DriverProfile>> GetAvailableDriversAsync()
    {
        return await _context.DriverProfiles.
            Where((d => d.IsAvailable && d.IsApproved)).ToListAsync();
    }

    public async Task AddDriverProfileAsync(DriverProfile profile)
    {
        await _context.DriverProfiles.AddAsync(profile);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDriverProfileAsync(DriverProfile profile)
    {
        await _context.SaveChangesAsync();
    }
}