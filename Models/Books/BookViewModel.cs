using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookland.Models.Books
{
    public class BookViewModel
    {
        public List<Book> Book { get; set; }
        public List<Category> Category { get; set; }
        public List<Author> Author { get; set; }
    }
}