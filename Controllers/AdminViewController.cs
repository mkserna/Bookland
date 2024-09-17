using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bookland.Database;
using Bookland.Models.Books;

namespace Bookland.Controllers
{
    [Route("[controller]")]
    public class AdminViewController : Controller
    {
        private readonly ILogger<AdminViewController> _logger;
        private readonly AppDbContext _context;


        public AdminViewController(ILogger<AdminViewController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("Admin")]
        public IActionResult Admin()
        {
            var allBooks = _context.Books.ToList();
            var allAuthors = _context.Authors.ToList();
            var allCategories = _context.Categories.ToList();

            var MiViewModel = new BookViewModel
            {
                Book = allBooks,
                Author = allAuthors,
                Category = allCategories
            };

            return View(MiViewModel);
        }

        [HttpGet("Admin/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var BookInDb = _context.Books.SingleOrDefault(b => b.Id == id);
            _context.Books.Remove(BookInDb);
            _context.SaveChanges();
            return RedirectToAction(nameof(Admin));  // deleting  the view, waitig to get Mariana name of the view

        }



        // here I am finding it Updating that Book
        [HttpGet("Admin/UpdateBook/{id}")]
        public IActionResult UpdateBook(int id)
        {
            if (id != null)
            {

                var BookInDb = _context.Books.SingleOrDefault(b => b.Id == id);
                return View(BookInDb);
            }
            return RedirectToAction("Admin");
        }

        // here showing The form of the book
        [HttpPost("Admin/CreateUpdateForm/{id}")]
        public IActionResult CreateUpdateForm(Book model)
        {
            if (model.Id == 0)
            {
                _context.Books.Add(model);
            }
            else
            {
                _context.Books.Update(model);
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return RedirectToAction("Admin");
            }
            return RedirectToAction("Admin");    //adentro va la vista de los todos los libros.
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}