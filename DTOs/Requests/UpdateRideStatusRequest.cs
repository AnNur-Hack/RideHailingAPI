using RideHailingAPI.Domain.Enums;

namespace RideHailingAPI.DTOs.Requests;

public class UpdateRideStatusRequest
{
    public RideStatus Status { get; set; }
}