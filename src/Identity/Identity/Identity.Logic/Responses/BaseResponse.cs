namespace Identity.Logic.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<string>? ValidationErrors { get; set; }

        public BaseResponse()
        {
            Success = true;
            Message = string.Empty;
            ValidationErrors = new List<string>();
        }

        public BaseResponse(string? message = null)
        {
            Success = true;
            Message = message;
        }

        public BaseResponse(string message, bool success, string validationError)
        {
            Success = success;
            Message = message;
            ValidationErrors?.Add(validationError);
        }
    }
}