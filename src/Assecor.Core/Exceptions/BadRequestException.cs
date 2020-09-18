namespace Assecor.Core.Exceptions
{
    public class BadRequestException : ExceptionWithStatusCode
    {
        public BadRequestException(string message)
            : base(message)
        {
            StatusCode = 400;
        }
    }
}