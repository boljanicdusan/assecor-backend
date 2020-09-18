using Assecor.Core.Exceptions;
using Assecor.Core.Persons;

namespace Assecor.CSV.Helpers
{
    public static class CSVConverter
    {
        /// <summary>Converts CSV line to a person object</summary>
        /// <param name="csvLine"></param>
        /// <param name="lineNumber"></param>
        /// <exception cref="InvalidCSVLineException"></exception>
        /// <exception cref="InvalidColorIdException"></exception>
        public static Person ConvertToPerson(string csvLine, int lineNumber)
        {
            string[] values = csvLine.Split(',');

            if (values.Length < 4)
            {
                throw new InvalidCSVLineException(lineNumber);
            }

            int colorId;
            if (int.TryParse(values[3], out colorId))
            {
                return new Person
                {
                    Id = lineNumber,
                    FirstName = values[0],
                    LastName = values[1],
                    Address = values[2],
                    ColorId = colorId
                };
            }
            else
            {
                throw new InvalidColorIdException(values[3]);
            }
            
        }


        /// <summary>Converts a person object into CSV line</summary>
        /// <param name="person"></param>
        public static string ConvertFromPerson(Person person)
        {
            return $"{person.FirstName}, {person.LastName}, {person.Address}, {person.ColorId}";
        }
    }
}