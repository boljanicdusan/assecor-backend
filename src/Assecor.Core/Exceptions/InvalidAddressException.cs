using System;

namespace Assecor.Core.Exceptions
{
    public class InvalidAddressException : Exception
    {
        public InvalidAddressException(string address)
            : base($"Invalid address {address}. It should contain zip code and city")
        {

        }
    }
}