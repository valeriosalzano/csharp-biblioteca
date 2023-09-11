using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Loan
    {
        // PROPERTIES
        public User User { get; set; }
        public Document Document { get; set; }
        public string LoanStartDate { get; set; }
        public string LoanEndDate { get; set; }

        // CONSTRUCTORS
        public Loan(User user, Document document, string startDate, string endDate)
        {
            this.User = user;
            this.Document = document;
            this.LoanStartDate = startDate;
            this.LoanEndDate = endDate;

        }
    }
}
