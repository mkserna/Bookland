using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookland.Models.Users;
using Bookland.Models.Books;

namespace Bookland.Models.Loans
{
    public class Loan
    {
        public int Id { get; set; }
        public DateOnly LoanDate { get; set; }
        public DateOnly ExpectedReturnDate { get; set; }

        // Claves Foraneas
        public int UserId {get; set;}
        public int BookId {get; set;}


        // Relaciones con otras entidades
        public User User { get; set; }
        public Book Book { get; set; }
        public ICollection<LoanHistory> loanHistory {get; set;}

    }
}