using System;

namespace Assecor.Core.Exceptions
{
    public class InvalidColorIdException : Exception
    {
        public InvalidColorIdException(string colorId)
            : base($"Invalid color ID {colorId}")
        {
            
        }
    }
}