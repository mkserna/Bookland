using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookland.Models.Books;
using Bookland.Models.Loans;
using Bookland.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Bookland.Database
{
    public class AppDbContext : DbContext
    {

        // Libros
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Usuarios
        public DbSet<User> Users { get; set; }
        public DbSet<DocumentType> DocumentsTypes { get; set; }
        public DbSet<Role> Roles { get; set; }

        // Prestamos
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanHistory> HistoryLoans { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
    }
}