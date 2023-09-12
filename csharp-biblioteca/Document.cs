using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Document
    {
        //STATE

        public bool isLent;

        // PROPERTIES
        public string ID { get; private set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Subject { get; set; }
        public string Shelf {  get; set; }
        public Author Author { get; set; }

        // CONSTRUCTORS
        public Document(string title, int year, string subject, string shelf, Author author)
        {
            SetRandomID(8);

            this.Title = title;
            this.Year = year;
            this.Subject = subject;
            this.Shelf = shelf;
            this.Author = author;
        }
        // SETTERS

        private void SetRandomID(int n)
        {
            string randomID = "";

            string chars = "abcdefghijklmnopqrstuvwyz1234567890";
            for (int i = 0; i < n; i++)
            {
                randomID += chars[new Random().Next(0, chars.Length)];
            }
            this.ID = randomID;
        }

        // METHODS
        public override string ToString()
        {
            return @$"
            Informazioni sul documento:
            ID : {this.ID}
            Titolo: {this.Title}
            Anno: {this.Year}
            Settore: {this.Subject}
            Scaffale: {this.Shelf}
            Autore: {this.Author.Name} {this.Author.Surname}
            ";
        }

        
    }
}
