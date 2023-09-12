using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Library
    {
        private List<Document> Documents;
        private List<User> Users;
        private List<Loan> Loans;

        // CONSTRUCTOR
        public Library() 
        {
            this.Documents = new List<Document>();
            this.Users = new List<User>();
            this.Loans = new List<Loan>();
        }
        public Library(List<Document> documents, List<User> users)
        {
            this.Documents = documents;
            this.Users = users;
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
            List<User> users = this.Users.FindAll(user => (user.Name == name && user.Surname == surname));

            if(users.Count == 0)
            {
                // TODO exception needed
                return null;
            }
            else if(users.Count > 1) // case of homonymy
            {
                Console.WriteLine("Ci sono più utenti con lo stesso nome. Consigliamo la ricerca per email");
                //TODO exception neeeded
                return null;
            }
            else
            {
                return users[0];
            }
        }
        public User GetUser(string email)
        {
            // TODO possible null return
            return this.Users.Find(user => user.Email == email);
        }

        public List<Loan> GetLoans(string name, string surname)
        {
            User user = this.GetUser(name, surname);
            if(user == null)
            {
                return null; // TODO exception needed
            }
            return this.Loans.FindAll(loan => loan.UserEmail == user.Email);
        }
        public List<Loan> GetLoans(string email)
        {
            return this.Loans.FindAll(loan => loan.UserEmail == email);
        }

        // METHODS
        public void AddLoan(string userEmail, string documentParam, DateTime startDate)
        {
            if (this.Users.Find(user => user.Email == userEmail) == null) // subscribed check
                Console.WriteLine("Il prestito è consentito solo agli utenti registrati.");
            else 
            {
                Document document = this.GetDocumentByID(documentParam);
                if (document == null) // found by id check
                    document = this.GetDocumentByTitle(documentParam);
                if (document == null) // found by title check
                {
                    Console.WriteLine("Il documento non è stato trovato.");
                    return;
                }

                if (document.isLent) //isLent check
                    Console.WriteLine("Il documento è stato già prestato.");
                else
                {
                    document.isLent = true;
                    this.Loans.Add(new Loan(userEmail, document.ID, startDate));
                }
            }
        }

        public void CloseLoan(string userEmail, string documentParam, DateTime endDate)
        {
            if (this.Users.Find(user => user.Email == userEmail) == null) // subscribed check
                Console.WriteLine("Il prestito è consentito solo agli utenti registrati.");
            else
            {
                Document document = this.GetDocumentByID(documentParam);

                if (document == null) // document found by id check
                    document = this.GetDocumentByTitle(documentParam);
                if (document == null) // document found by title check
                {
                    Console.WriteLine("Il documento non è stato trovato.");
                    return;
                }

                Loan loan = this.Loans.FindLast(loan => (loan.DocumentId == document.ID && loan.UserEmail == userEmail));
                if (loan == null) // loan found check
                    Console.WriteLine("Il prestito non è stato trovato.");
                else
                {
                    if (!document.isLent) //isLent check
                        Console.WriteLine("Il documento risulta rientrato.");
                    else
                    {
                        loan.LoanEndDate = endDate;
                        document.isLent = false;
                    }
                }
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
