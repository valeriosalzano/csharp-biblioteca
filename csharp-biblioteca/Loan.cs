using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Loan
    {
        // PROPERTIES
        public string UserEmail { get; set; }
        public string DocumentId { get; set; }
        public DateTime LoanStartDate { get; set; }
        public DateTime LoanEndDate { get; set; }

        // CONSTRUCTORS
        public Loan(string userEmail, string documentId, DateTime startDate, DateTime endDate)
        {
            this.UserEmail = userEmail;
            this.DocumentId = documentId;
            this.LoanStartDate = startDate;
            this.LoanEndDate = endDate;

        }
    }
}
