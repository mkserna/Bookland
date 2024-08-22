using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookland.Models.Book
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public bool Availability { get; set; }

        // Relaciones con las otras entidades
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}