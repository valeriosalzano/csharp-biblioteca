using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Library
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
    }
}
