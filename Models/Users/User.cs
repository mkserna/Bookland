using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookland.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public DocumentType DocumentType { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public Role Role { get; set; }
    }
}