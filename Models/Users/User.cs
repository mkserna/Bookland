using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookland.Models.Loans;

namespace Bookland.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        
        // Claves foraneas
        public int DocumentTypeId { get; set; }
        public int RoleId { get; set; }
        
        
        // Relaciones con las otras entidades
        public DocumentType DocumentType { get; set; }

        public Role Role { get; set; }
        public ICollection<Loan> Loans {get; set;}
    }
}