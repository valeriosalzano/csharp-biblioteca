using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Author
    {
        // PROPERTIES
        public string Name { get; set; }
        public string Surname { get; set; }

        // CONSTRUCTORS
        public Author(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
    }
}
