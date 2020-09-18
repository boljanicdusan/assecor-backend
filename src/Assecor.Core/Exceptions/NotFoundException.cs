using System;

namespace Assecor.Core.Exceptions
{
    public class NotFoundException : ExceptionWithStatusCode
    {
        public NotFoundException(string message)
            : base(message)
        {
            StatusCode = 404;
        }
    }
}