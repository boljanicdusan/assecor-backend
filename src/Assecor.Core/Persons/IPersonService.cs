using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assecor.Core.Persons
{
    public interface IPersonService
    {
        /// <summary>Returns all persons</summary>
        Task<List<PersonDto>> GetPersons();

        /// <summary>Returns a person with the given id</summary>
        /// <param name="id"></param>
        Task<PersonDto> GetPersonById(int id);

        /// <summary>Returns all persons with the given favorite color</summary>
        /// <param name="color"></param>
        Task<List<PersonDto>> GetPersonsByColor(string color);

        /// <summary>Creates a new person</summary>
        /// <param name="person">Type of PersonDto</param>
        Task CreatePerson(PersonDto person);
    }
}