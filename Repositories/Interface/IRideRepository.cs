using RideHailingAPI.Domain.Entities;

namespace RideHailingAPI.Repositories.Interface;

public interface IRideRepository
{
    public Task<Ride?> GetRideByRideReferenceAsync(string rideReference);
    public Task<Ride?> GetRideByIdAsync(int id);
    public Task<List<Ride>> GetPassengerRidesAsync(int passengerId);
    public Task<List<Ride>> GetDriverRidesAsync(int driverId);
    
    public Task AddRideAsync(Ride ride);
    public Task UpdateRideAsync(Ride ride);
}