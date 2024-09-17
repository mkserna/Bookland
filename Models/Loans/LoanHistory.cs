using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookland.Models.Loans
{
    public class LoanHistory
    {
        public int Id { get; set; }
        public DateOnly ActualReturnDate { get; set; }
        
        // Claves Foraneas
        public int LoanID {get; set;}
        
        
        // Relaciones con otras entidades
        public Loan Loan { get; set; }
        
    }
}