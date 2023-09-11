using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class DVD : Document
    {
        // PROPERTIES
        public int LengthInMinutes { get; set; }

        // CONSTRUCTORS
        public DVD(string title, int year, string subject, string shelf, Author author, int lengthInMinutes) : base(title, year, subject, shelf, author)
        {
            this.LengthInMinutes = lengthInMinutes;
        }
    }
}
