namespace Assecor.Core.Exceptions
{
    public class ColorNotFoundException : NotFoundException
    {
        public ColorNotFoundException(int colorId)
            : base($"Color with id {colorId} not found")
        {

        }

        public ColorNotFoundException(string colorName)
            : base($"Color with name {colorName} not found")
        {

        }
    }
}