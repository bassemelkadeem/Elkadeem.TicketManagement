namespace Elkadeem.TicketManagement.Application.Responses
{
    public abstract class BaseResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; } = string.Empty;

        public List<string>? ValidationErrors { get; set; }

        public BaseResponse()
        {
            IsSuccess = true;
        }

        public BaseResponse(string message)
        {
            Message = message;
            IsSuccess = true;
        }

        public BaseResponse(string message, bool isSuccess)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
