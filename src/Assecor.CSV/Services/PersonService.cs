using Assecor.Core.Colors;
using Assecor.Core.Persons;
using Assecor.CSV.Helpers;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assecor.CSV.Services
{
    public class PersonService : IPersonService
    {
        private readonly FileConnectionsConfiguration _fileConnectionsConfiguration;
        private readonly IMapper _mapper;

        public PersonService(FileConnectionsConfiguration fileConnectionsConfiguration, IMapper mapper)
        {
            _fileConnectionsConfiguration = fileConnectionsConfiguration;
            _mapper = mapper;
        }

        public async Task<List<PersonDto>> GetPersons()
        {
            var csvLines = await CSVFileReader.ReadAllLinesAsync(_fileConnectionsConfiguration.FilePath);
            var persons = csvLines.Select((csvLine, index) => CSVConverter.ConvertToPerson(csvLine, index + 1)).ToList();
            return _mapper.Map<List<Person>, List<PersonDto>>(persons);
        }

        public async Task<PersonDto> GetPersonById(int id)
        {
            var csvLine = await CSVFileReader.ReadLineAtAsync(_fileConnectionsConfiguration.FilePath, id);
            var person = CSVConverter.ConvertToPerson(csvLine, id);
            return _mapper.Map<Person, PersonDto>(person);
        }

        public async Task<List<PersonDto>> GetPersonsByColor(string color)
        {
            var csvLines = await CSVFileReader.ReadAllLinesAsync(_fileConnectionsConfiguration.FilePath);
            var persons = csvLines.Select((csvLine, index) => CSVConverter.ConvertToPerson(csvLine, index + 1))
                                .Where(person => person.ColorId == DefaultColors.GetColorIdByName(color))
                                .ToList();
            return _mapper.Map<List<Person>, List<PersonDto>>(persons);
        }

        public async Task CreatePerson(PersonDto personDto)
        {
            var person = _mapper.Map<PersonDto, Person>(personDto);
            var csvLine = CSVConverter.ConvertFromPerson(person);
            await CSVFileWriter.AppendLineAsync(_fileConnectionsConfiguration.FilePath, csvLine);
        }
    }
}