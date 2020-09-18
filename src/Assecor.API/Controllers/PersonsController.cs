using System;
using System.Threading.Tasks;
using Assecor.Core.Persons;
using Microsoft.AspNetCore.Mvc;

namespace Assecor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : BaseController
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<IActionResult> GetPersons()
        {
            try
            {
                var persons = await _personService.GetPersons();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                return Handle(ex);
            }
        }

        [Route("{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            try
            {
                var person = await _personService.GetPersonById(id);
                return Ok(person);
            }
            catch (System.Exception ex)
            {
                return Handle(ex);
            }
        }

        [Route("color/{color}")]
        public async Task<IActionResult> GetPersonsByColor(string color)
        {
            try
            {
                var persons = await _personService.GetPersonsByColor(color);
                return Ok(persons);
            }
            catch (System.Exception ex)
            {
                return Handle(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonDto person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                await _personService.CreatePerson(person);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return Handle(ex);
            }
        }
    }
}