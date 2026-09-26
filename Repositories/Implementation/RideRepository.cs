using Microsoft.EntityFrameworkCore;
using RideHailingAPI.Data;
using RideHailingAPI.Domain.Entities;
using RideHailingAPI.Repositories.Interface;

namespace RideHailingAPI.Repositories.Implementation;

public class RideRepository(ApplicationDbContext context) : IRideRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Ride?> GetRideByRideReferenceAsync(string rideReference)
    {
        return await _context.Rides.FirstOrDefaultAsync(r => r.RideReference == rideReference);
    }

    public async Task<Ride?> GetRideByIdAsync(int id)
    {
       return await _context.Rides.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<List<Ride>> GetPassengerRidesAsync(int passengerId)
    {
        return await _context.Rides.Where(p => p.PassengerId == passengerId).ToListAsync();
    }

    public Task<List<Ride>> GetDriverRidesAsync(int driverId)
    {
        return _context.Rides.Where(p => p.DriverId == driverId).ToListAsync();
    }

    public async Task AddRideAsync(Ride ride)
    {
        await _context.Rides.AddAsync(ride);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRideAsync(Ride ride)
    {
        await _context.SaveChangesAsync();
    }
}