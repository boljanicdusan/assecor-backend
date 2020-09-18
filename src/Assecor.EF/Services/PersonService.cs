using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assecor.Core.Exceptions;
using Assecor.Core.Persons;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assecor.EF.Services
{
    public class PersonService : IPersonService
    {
        private readonly AssecorDbContext _context;
        private readonly IMapper _mapper;

        public PersonService(AssecorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PersonDto>> GetPersons()
        {
            var persons = await _context.Persons.Include(p => p.Color).ToListAsync();
            return _mapper.Map<List<Person>, List<PersonDto>>(persons);
        }

        public async Task<PersonDto> GetPersonById(int id)
        {
            var person = await _context.Persons.Include(p => p.Color).FirstOrDefaultAsync(p => p.Id == id);
            if (person != null)
            {
                return _mapper.Map<Person, PersonDto>(person);
            }

            throw new PersonNotFoundException(id);
        }

        public async Task<List<PersonDto>> GetPersonsByColor(string color)
        {
            bool colorExists = await _context.Colors.AnyAsync(c => c.Name == color);
            if (!colorExists)
            {
                throw new ColorNotFoundException(color);
            }
            
            var persons = await _context.Persons.Include(p => p.Color).Where(p => p.Color.Name == color).ToListAsync();
            return _mapper.Map<List<Person>, List<PersonDto>>(persons);
        }

        public async Task CreatePerson(PersonDto personDto)
        {
            var color = await _context.Colors.FirstOrDefaultAsync(c => c.Name == personDto.Color);
            if (color == null)
            {
                throw new ColorNotFoundException(personDto.Color);
            }
            
            var person = _mapper.Map<PersonDto, Person>(personDto);
            person.Id = 0;
            person.ColorId = color.Id;
            
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }
    }
}