using System;

namespace Assecor.Core.Exceptions
{
    public class InvalidCSVLineException : Exception
    {
        public InvalidCSVLineException(int lineNumber)
            : base($"CSV line {lineNumber} is invalid and could not be parsed into Person")
        {
            
        }
    }
}