using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookland.Models.Books
{
    public class Category
    {
         public int Id { get; set; }
        public string CategoryName { get; set; }

        // Propiedad de navegación: una categoría puede tener varios libros
        public ICollection<Book> Books { get; set; }
    }
}