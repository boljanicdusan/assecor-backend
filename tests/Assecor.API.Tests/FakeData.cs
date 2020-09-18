using System.Collections.Generic;
using Assecor.Core.Persons;

namespace Assecor.API.Tests
{
    public class FakeData
    {
        public static List<PersonDto> GetPersonsList()
        {
            return new List<PersonDto>
            {
                new PersonDto
                {
                    Id = 1,
                    FirstName = "Dusan",
                    LastName = "Boljanic",
                    ZipCode = "12345",
                    City = "Podgorica",
                    Color = "blau"
                },
                new PersonDto
                {
                    Id = 2,
                    FirstName = "Ema",
                    LastName = "Sabotic",
                    ZipCode = "12345",
                    City = "Berane",
                    Color = "rot"
                },
                new PersonDto
                {
                    Id = 3,
                    FirstName = "Pavle",
                    LastName = "Aligrudic",
                    ZipCode = "12345",
                    City = "Podgorica",
                    Color = "blau"
                },
            };
        }


        public static List<PersonDto> GetPersonsListWithFavoriteColorBlue()
        {
            return new List<PersonDto>
            {
                new PersonDto
                {
                    Id = 1,
                    FirstName = "Dusan",
                    LastName = "Boljanic",
                    ZipCode = "12345",
                    City = "Podgorica",
                    Color = "blau"
                },
                new PersonDto
                {
                    Id = 3,
                    FirstName = "Pavle",
                    LastName = "Aligrudic",
                    ZipCode = "12345",
                    City = "Podgorica",
                    Color = "blau"
                },
            };
        }

        public static PersonDto GetSinglePerson()
        {
            return new PersonDto
            {
                Id = 1,
                FirstName = "Dusan",
                LastName = "Boljanic",
                ZipCode = "12345",
                City = "Podgorica",
                Color = "blau"
            };
        }

        public static PersonDto GetSinglePersonWithInvalidFirstName()
        {
            return new PersonDto
            {
                Id = 1,
                FirstName = null,
                LastName = "Boljanic",
                ZipCode = "12345",
                City = "Podgorica",
                Color = "blau"
            };
        }

        public static PersonDto GetSinglePersonWithNonexistentColor()
        {
            return new PersonDto
            {
                Id = 1,
                FirstName = "Dusan",
                LastName = "Boljanic",
                ZipCode = "12345",
                City = "Podgorica",
                Color = "new_color"
            };
        }
    }
}