using System.IO;
using System.Threading.Tasks;

namespace Assecor.CSV.Helpers
{
    public static class CSVFileWriter
    {
        /// <summary>Appends a CSV line in the given CSV file</summary>
        /// <param name="filePath"></param>
        /// <param name="csvLine"></param>
        /// <exception cref="FileNotFoundException"></exception>
        public static async Task AppendLineAsync(string filePath, string csvLine)
        {
            if (File.Exists(filePath))
            {
                var text = File.ReadAllText(filePath);
                if (text.EndsWith('\n'))
                {
                    await File.AppendAllLinesAsync(filePath, new string[] { csvLine });
                }
                else
                {
                    // if the CSV file's content doesn't end with a new line,
                    // add a new line before appending the given CSV line
                    await File.AppendAllLinesAsync(filePath, new string[] { "", csvLine });
                }
            }
            else
            {
                throw new FileNotFoundException($"File {filePath} not found");
            }
        }
    }
}