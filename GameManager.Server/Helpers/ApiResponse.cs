namespace GameManager.Server.Helpers;

public static class ApiResponse
{
    public static object Success(object data = null, string message = "Success")
    {
        return new
        {
            Success = true,
            Message = message,
            Data = data
        };
    }

    public static object Error(string message = "Error", object errors = null)
    {
        return new
        {
            Success = false,
            Message = message,
            Errors = errors
        };
    }
}