using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Book : Document
    {
        // PROPERTIES
        public int Pages { get; set; }

        // CONSTRUCTORS
        public Book(string title, int year, string subject, string shelf, Author author, int pages) : base(title, year, subject, shelf, author)
        {
            this.Pages = pages;
        }

    }
}
