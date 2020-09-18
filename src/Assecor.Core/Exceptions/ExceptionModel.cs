namespace Assecor.Core.Exceptions
{
    public class ExceptionModel
    {
        public ExceptionModel(string errorMessage, int? statusCode = null)
        {
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }
        
        public string ErrorMessage { get; set; }
        public int? StatusCode { get; set; }
    }
}