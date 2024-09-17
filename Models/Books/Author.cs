using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookland.Models.Books
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }

        // Propiedad de navegación: un autor puede tener varios libros
        public ICollection<Book> Books { get; set; }

    }
}