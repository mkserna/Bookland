using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookland.Models.Users
{
    public class DocumentType
    {
        public int Id { get; set; }
        public string Documenttype { get; set; }
        

        public ICollection<User> Users {get; set;}
    }
}