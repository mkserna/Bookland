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
        public User User { get; set; }
        public Book Book { get; set; }

    }
}