using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Document
    {
        // PROPERTIES
        public string ID { get; private set; }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public string Subject { get; private set; }
        public string Shelf {  get; private set; }
        public Author Author { get; private set; }

        // CONSTRUCTORS
        public Document(string title, int year, string subject, string shelf, Author author)
        {
            this.ID = "randId"; //TODO - generare ID alfanumerico randomicamente

            this.Title = title;
            this.Year = year;
            this.Subject = subject;
            this.Shelf = shelf;
            this.Author = author;
        }
    }
}
