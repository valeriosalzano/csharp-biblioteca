using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class DVD : Document
    {
        // PROPERTIES
        public int LengthInMinutes { get; set; }

        // CONSTRUCTORS
        public DVD(string title, int year, string subject, string shelf, Author author, int lengthInMinutes) : base(title, year, subject, shelf, author)
        {
            this.LengthInMinutes = lengthInMinutes;
        }
        // METHODS
        public override string ToString()
        {
            return (base.ToString() + @$"Durata: {this.LengthInMinutes} minuti");
        }
        // SEEDER   
        static public List<DVD> DVDsSeeder(int n)
        {
            string[] subjects = { "matematica", "storia", "economia", "geografia", "fisica" };
            string[] shelves = { "A", "B", "C", "D", "E", "F", "G", "H", "I" };

            List<DVD> list = new List<DVD>();

            for (int i = 0; i < n; i++)
            {
                list.Add(new DVD(
                    "titoloDVD" + i,
                    new Random().Next(1000, 2024),
                    subjects[new Random().Next(0, (subjects.Length))],
                    shelves[new Random().Next(0, shelves.Length)] + new Random().Next(0, 20),
                    new Author("nomeAutore", "cognomeAutore"),
                    new Random().Next(10, 120)
                    ));
            }

            return list;
        }
    }
}
