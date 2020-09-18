using Xunit;
using System.Threading.Tasks;
using Assecor.Core.Persons;
using Moq;
using Assecor.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Assecor.Core.Exceptions;

namespace Assecor.API.Tests
{
    public class PersonsController_Test
    {
        [Fact]
        public async Task GetPersons_ReturnsStatusOk()
        {
            // Arrange
            var persons = FakeData.GetPersonsList();

            var mockService = new Mock<IPersonService>();
            mockService.Setup(service => service.GetPersons()).ReturnsAsync(persons);

            var personsController = new PersonsController(mockService.Object);

            // Act
            var result = await personsController.GetPersons();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(okObjectResult.Value, persons);
        }

        [Fact]
        public async Task GetPersonById_ReturnsStatusOk()
        {
            // Arrange
            var personId = 1;
            var person = FakeData.GetSinglePerson();

            var mockService = new Mock<IPersonService>();
            mockService.Setup(service => service.GetPersonById(personId)).ReturnsAsync(person);

            var personsController = new PersonsController(mockService.Object);

            // Act
            var result = await personsController.GetPersonById(personId);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(person, okObjectResult.Value);
        }

        [Fact]
        public async Task GetPersonById_ReturnsStatusNotFound()
        {
            // Arrange
            var personId = 5;
            var expectedStatusCode = 404;

            var mockService = new Mock<IPersonService>();
            mockService.Setup(service => service.GetPersonById(personId)).ThrowsAsync(new PersonNotFoundException(personId));

            var personsController = new PersonsController(mockService.Object);

            // Act
            var result = await personsController.GetPersonById(personId);

            // Assert
            Assert.Equal((result as ObjectResult).StatusCode, expectedStatusCode);
        }

        [Fact]
        public async Task GetPersonsByColor_ReturnsStatusOk()
        {
            // Arrange
            var color = "blau";
            var persons = FakeData.GetPersonsListWithFavoriteColorBlue();

            var mockService = new Mock<IPersonService>();
            mockService.Setup(service => service.GetPersonsByColor(color)).ReturnsAsync(persons);

            var personsController = new PersonsController(mockService.Object);

            // Act
            var result = await personsController.GetPersonsByColor(color);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(persons, okObjectResult.Value);
        }
        
        [Fact]
        public async Task GetPersonsByColor_ReturnsStatusNotFound()
        {
            // Arrange
            var color = "invalid_color";
            var expectedStatusCode = 404;

            var mockService = new Mock<IPersonService>();
            mockService.Setup(service => service.GetPersonsByColor(color)).ThrowsAsync(new ColorNotFoundException(color));

            var personsController = new PersonsController(mockService.Object);

            // Act
            var result = await personsController.GetPersonsByColor(color);

            // Assert
            Assert.Equal((result as ObjectResult).StatusCode, expectedStatusCode);
        }
        

        [Fact]
        public async Task CreatePerson_ReturnsStatusOk()
        {
            // Arrange
            var person = FakeData.GetSinglePerson();

            var mockService = new Mock<IPersonService>();
            mockService.Setup(service => service.CreatePerson(person));

            var personsController = new PersonsController(mockService.Object);

            // Act
            var result = await personsController.CreatePerson(person);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task CreatePerson_ReturnsStatusBadRequest()
        {
            // Arrange
            var person = FakeData.GetSinglePersonWithInvalidFirstName();
            var expectedStatusCode = 400;

            var mockService = new Mock<IPersonService>();
            mockService.Setup(service => service.CreatePerson(person));

            var personsController = new PersonsController(mockService.Object);
            personsController.ModelState.AddModelError("FirstName", "The FirstName field is required.");

            // Act
            var result = await personsController.CreatePerson(person);

            // Assert
            Assert.Equal((result as ObjectResult).StatusCode, expectedStatusCode);
        }

        [Fact]
        public async Task CreatePerson_ReturnsStatusNotFound()
        {
            // Arrange
            var person = FakeData.GetSinglePersonWithNonexistentColor();
            var expectedStatusCode = 404;

            var mockService = new Mock<IPersonService>();
            mockService.Setup(service => service.CreatePerson(person)).ThrowsAsync(new ColorNotFoundException(person.Color));

            var personsController = new PersonsController(mockService.Object);

            // Act
            var result = await personsController.CreatePerson(person);

            // Assert
            Assert.Equal((result as ObjectResult).StatusCode, expectedStatusCode);
        }
    }
}