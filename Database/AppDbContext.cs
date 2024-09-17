using System;
using System.Collections.Generic;
using System.IO.Compression;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Creacion de tablas

            // --- Tabla Libro
            modelBuilder.Entity<Book>(table => 
            {
                // ID
                table.HasKey(column => column.Id);

                table.Property(column => column.Id)
                .HasColumnName("IdBook")
                .UseMySqlIdentityColumn()
                .ValueGeneratedOnAdd();

                // Titulo
                table.Property(column => column.Title).HasMaxLength(255);

                // ISBN
                table.Property(column => column.ISBN).HasMaxLength(13);

                // Disponibilidad
                table.Property(column => column.Availability).HasDefaultValue(true);

                // Summary
                table.Property(column => column.Summary).HasMaxLength(255);
            });

            // ------ Tabla Autor

            modelBuilder.Entity<Author>(table => 
            {
                // ID
                table.HasKey(column => column.Id);

                table.Property(column => column.Id)
                .HasColumnName("IdAuthor")
                .UseMySqlIdentityColumn()
                .ValueGeneratedOnAdd();

                // AuthorName
                table.Property(column => column.AuthorName).HasMaxLength(255);
            });

            // -------- Tabla Categories

            modelBuilder.Entity<Category>(table => 
            {
                // ID
                table.HasKey(column => column.Id);

                table.Property(column => column.Id)
                .HasColumnName("IdCategory")
                .UseMySqlIdentityColumn()
                .ValueGeneratedOnAdd();

                // Category name
                table.Property(column => column.CategoryName).HasMaxLength(255);
            });



            // -------- Tabla User

            modelBuilder.Entity<User>(table =>
            {
                // ID
                table.HasKey(column => column.Id);

                table.Property(column => column.Id)
                .HasColumnName("IdUser")
                .UseMySqlIdentityColumn()
                .ValueGeneratedOnAdd();

                // DocumentNumber
                table.Property(column => column.DocumentNumber).HasMaxLength(10);

                // Name
                table.Property(column => column.Name).HasMaxLength(100);

                // LastName
                table.Property(column => column.LastName).HasMaxLength(100);

                //Address
                table.Property(column => column.Address).HasMaxLength(255);

                // ContactNumber
                table.Property(column => column.ContactNumber).HasMaxLength(15);

                // Email
                table.Property(column => column.Email).HasMaxLength(255);

                // Password
                table.Property(column => column.Password).HasMaxLength(100);
            });



            // -------- Tabla Loan


            modelBuilder.Entity<Loan>(table => 
            {
                // ID
                table.HasKey(column => column.Id);

                table.Property(column => column.Id)
                .HasColumnName("IdLoan")
                .UseMySqlIdentityColumn()
                .ValueGeneratedOnAdd();

                // Loan Date
                table.Property(column => column.LoanDate).HasColumnType("date");

                // Expected Return Date
                table.Property(column => column.ExpectedReturnDate).HasColumnType("date");
                
            });

            // -------- Tabla LoanHistory
            modelBuilder.Entity<LoanHistory>(table =>
            {
                // ID
                table.HasKey(column => column.Id);

                table.Property(column => column.Id)
                .HasColumnName("IdLoanHistory")
                .UseMySqlIdentityColumn()
                .ValueGeneratedOnAdd();

                // Actual Return Date
                table.Property(column => column.ActualReturnDate)
                .HasColumnType("date");

            });




            // Configuracion relacional
            
            // Configuración de la relación entre Book y Author
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            // Configuración de la relación entre Book y Category
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);
            
            
            // Configuración de la relación entre User y DocumentType
            modelBuilder.Entity<User>()
                .HasOne(u => u.DocumentType)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DocumentTypeId);

            // Configuración de la relación entre User y Role
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            
            // Configuración de la relación entre Loan y Book
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookId);


            // Configuración de la relación entre Loan y User
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.User)
                .WithMany(u => u.Loans)
                .HasForeignKey(u => u.UserId);

            // Configuración de la relación entre Loan y LoanHistory
            modelBuilder.Entity<LoanHistory>()
                .HasOne(l => l.Loan)
                .WithMany(l => l.loanHistory)
                .HasForeignKey(l => l.LoanID);

            


        }

    }
}