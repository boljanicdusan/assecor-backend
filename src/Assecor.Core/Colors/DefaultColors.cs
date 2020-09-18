using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Assecor.Core.Exceptions;

namespace Assecor.Core.Colors
{
    public class DefaultColors
    {
        private static List<Color> _colors = new List<Color>
        {
            new Color(1, "blau"),
            new Color(2, "grün"),
            new Color(3, "violett"),
            new Color(4, "rot"),
            new Color(5, "gelb"),
            new Color(6, "türkis"),
            new Color(7, "weiß"),
        };

        /// <summary>Read-only list of default colors</summary>
        public static ReadOnlyCollection<Color> Colors => _colors.AsReadOnly();


        // Helper methods to get color by id or name //
        
        
        /// <summary>Returns color name by color id</summary>
        /// <param name="id"></param>
        /// <exception cref="ColorNotFoundException">If color with the given id doesn't exist</exception>
        public static string GetColorNameById(int id)
        {
            var color = _colors.FirstOrDefault(c => c.Id == id);
            if (color != null)
            {
                return color.Name;
            }

            throw new ColorNotFoundException(id);
        }


        /// <summary>Returns color id by color name</summary>
        /// <param name="name"></param>
        /// <exception cref="ColorNotFoundException">If color with the given name doesn't exist</exception>
        public static int GetColorIdByName(string name)
        {
            var color = _colors.FirstOrDefault(c => c.Name == name);
            if (color != null)
            {
                return color.Id;
            }

            throw new ColorNotFoundException(name);
        }
    }
}