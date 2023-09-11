using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Library
    {
        public List<Document> Documents;
        public List<User> Users;
        public List<Loan> Loans;

        // CONSTRUCTOR
        public Library() 
        {
            this.Documents = new List<Document>();
            this.Users = new List<User>();
            this.Loans = new List<Loan>();
        }

        // GETTER
        public Document GetDocumentByID(string id)
        {
            // TODO possible null return
            return this.Documents.Find(document => document.ID == id);

        }
        public Document GetDocumentByTitle(string title)
        {
            // TODO possible null return
            return this.Documents.Find(document => document.Title == title);
        }

                public User GetUser(string name, string surname)
        {

        }

        // METHODS
        public void AddLoan(string userEmail, string documentId, DateTime startDate, DateTime endDate)
        {
            //checking if user is subscribed
            if (this.Users.Find(user => user.Email == userEmail) != null) // success
            {
                //TODO some possible checks (book already lent, loans limit, unavailable dates)
                this.Loans.Add(new Loan(userEmail, documentId, startDate, endDate));
                

            } else // fail
            {
                Console.WriteLine("Il prestito è consentito solo agli utenti registrati.");
            }
        }

        public void AddUser(User user)
        {
            //checking already existing email
            string email = user.Email;
            foreach (User _user in this.Users)
            {
                if (_user.Email == email) //fail
                {
                    Console.WriteLine("Questa email risulta già registrata.");
                    return; // exception
                }
            }

            //success
            this.Users.Add(user);
        }

        public void AddDocument(Document document)
        {
            //TODO optionally check for duplicates
            this.Documents.Add(document);
        }
    }
}
