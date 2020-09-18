using System.ComponentModel.DataAnnotations;
using Assecor.Core.Colors;

namespace Assecor.Core.Persons
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}