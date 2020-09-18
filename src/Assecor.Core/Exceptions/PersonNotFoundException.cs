namespace Assecor.Core.Exceptions
{
    public class PersonNotFoundException : NotFoundException
    {
        public PersonNotFoundException(int id)
            : base($"Person with id {id} not found")
        {
            
        }
    }
}