using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookland.Models.Users
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        // Relaciones con las otras entidades
        public ICollection<User> Users {get; set;}

    }
}