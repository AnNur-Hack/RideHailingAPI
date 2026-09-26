using System.Security.Cryptography;

namespace RideHailingAPI.Helpers;

public static class OtpGenerator
{
    public static string GenerateOtp()
    {
        return RandomNumberGenerator.GetInt32(100000, 1000000).ToString();

    }
}