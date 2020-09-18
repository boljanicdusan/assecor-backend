using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assecor.Core.Exceptions;

namespace Assecor.CSV.Helpers
{
    public static class CSVFileReader
    {
        /// <summary>Reads and returns all CSV lines</summary>
        /// <param name="filePath"></param>
        /// <exception cref="FileNotFoundException"></exception>
        public static async Task<List<string>> ReadAllLinesAsync(string filePath)
        {
            if (File.Exists(filePath))
            {
                var csvLines = await File.ReadAllLinesAsync(filePath);
                return csvLines.ToList();
            }

            throw new FileNotFoundException($"File {filePath} not found");
        }


        /// <summary>Reads and returns CSV line with the given line number</summary>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <exception cref="PersonNotFoundException">Person at the given line number not found</exception>
        /// <exception cref="FileNotFoundException"></exception>
        public static async Task<string> ReadLineAtAsync(string filePath, int lineNumber)
        {
            if (File.Exists(filePath))
            {
                var csvLines = await File.ReadAllLinesAsync(filePath);
                var csvLine = csvLines.ElementAtOrDefault(lineNumber - 1);
                if (csvLine != null)
                {
                    return csvLine;
                }

                throw new PersonNotFoundException(lineNumber);
            }

            throw new FileNotFoundException($"File {filePath} not found");
        }
    }
}