using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookland.Models.Books
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public bool Availability { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        

        // Relaciones con las otras entidades
        public Author Author { get; set; }
        public Category Category { get; set; }
    }
}