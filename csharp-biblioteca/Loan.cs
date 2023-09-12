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
        public DateTime LoanEndDate { get; set; } = DateTime.MinValue;

        // CONSTRUCTORS
        public Loan(string userEmail, string documentId, DateTime startDate)
        {
            this.UserEmail = userEmail;
            this.DocumentId = documentId;
            this.LoanStartDate = startDate;
        }

        // METHODS
        public override string ToString()
        {
            return @$"
Informazioni sul prestito:
Email utente: {this.UserEmail}
ID documento: {this.DocumentId}
Prestato dal: {this.LoanStartDate}
Al: {(this.LoanEndDate==DateTime.MinValue? "non rientrato":this.LoanEndDate)}
            ";
        }
    }
}
