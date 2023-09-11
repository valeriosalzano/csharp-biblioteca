using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Book : Document
    {
        // PROPERTIES
        public int Pages { get; set; }

        // CONSTRUCTORS
        public Book(string title, int year, string subject, string shelf, Author author, int pages) : base(title, year, subject, shelf, author)
        {
            this.Pages = pages;
        }

        // METHODS
        public override string ToString()
        {
            return (base.ToString() + @$"Pagine: {this.Pages}");
        }
        // SEEDER
        static public List<Book> BooksSeeder(int n)
        {
            string[] subjects = { "matematica", "storia", "economia", "geografia", "fisica" };
            string[] shelves = { "A","B","C","D","E","F","G","H","I" };

            List<Book> list = new List<Book>();

            for (int i = 0; i<n; i++)
            {
                list.Add(new Book(
                    "titoloLibro" + i,
                    new Random().Next(1000, 2024),
                    subjects[new Random().Next(0, (subjects.Length))],
                    shelves[new Random().Next(0,shelves.Length)] + new Random().Next(0, 20),
                    new Author("nomeAutore", "cognomeAutore"),
                    new Random().Next(50, 500)
                    ));
            }

            return list;
        }

    }
}
