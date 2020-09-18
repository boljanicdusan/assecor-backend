using System;

namespace Assecor.Core.Exceptions
{
    public abstract class ExceptionWithStatusCode : Exception
    {
        public ExceptionWithStatusCode(string message)
            : base(message)
        {
            
        }
        
        public int StatusCode { get; set; }
    }
}