using System.ComponentModel.DataAnnotations;
using Assecor.Core.Exceptions;

namespace Assecor.Core.Persons
{
    public class PersonDto
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string City { get; set; }
        
        [Required]
        public string Color { get; set; }


        /// <summary>Returns zip code from the given address</summary>
        /// <param name="address"></param>
        /// <exception cref="InvalidAddressException"></exception>
        public static string GetZipCodeFromAddress(string address)
        {
            // Remove all leading and trailing white space chars
            address = address.Trim();

            // find the space between zip code and city
            var firstSpaceIndex = address.IndexOf(" ");
            if (firstSpaceIndex > 0)
            {
                return address.Substring(0, firstSpaceIndex);
            }
            
            throw new InvalidAddressException(address);
        }
        

        /// <summary>Returns city from the given address</summary>
        /// <param name="address"></param>
        /// <exception cref="InvalidAddressException"></exception>
        public static string GetCityFromAddress(string address)
        {
            // Remove all leading and trailing white space chars
            address = address.Trim();

            // find the space between zip code and city
            var firstSpaceIndex = address.IndexOf(" ");
            if (firstSpaceIndex > 0)
            {
                return address.Substring(firstSpaceIndex + 1, address.Length - firstSpaceIndex - 1);
            }
            
            throw new InvalidAddressException(address);
        }

        /// <summary>Returns address from the given zip code and city</summary>
        /// <param name="zipCode"></param>
        /// <param name="city"></param>
        public static string GetAddress(string zipCode, string city)
        {
            return $"{zipCode} {city}";
        }
    }
}