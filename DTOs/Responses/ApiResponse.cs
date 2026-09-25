namespace RideHailingAPI.DTOs.Responses;

public class ApiResponse<T>
{
    public string ResponseCode { get; set; }
    public string ResponseMessage { get; set; }
    public T? Data { get; set; }

    public static class ResponseHelper
    {
        public static ApiResponse<T> SuccessResponse<T>(T data, string message = "Operation Completed successfully")
        {
            return new ApiResponse<T>
            {
                ResponseCode = "00",
                ResponseMessage = message,
                Data = data,
            };
        }

        public static ApiResponse<T> FailureResponse<T>(string message)
        {
            return new ApiResponse<T>
            {
                ResponseCode = "99",
                ResponseMessage = message,
                Data = default,
            };
        }
    }
}