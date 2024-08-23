using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookland.Models;
using Bookland.Database;
using Microsoft.EntityFrameworkCore;
using Bookland.Models.Books;

public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;

    private readonly AppDbContext _context;

    public BookController(ILogger<BookController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    //calling the view of the books 

    public IActionResult books()
    {
        var allBooks =  _context.Books.ToList();
        return View(allBooks);
    }


    public IActionResult Delete(int id)
    {
        var BookInDb = _context.Books.SingleOrDefault(b => b.Id == id);
        _context.Books.Remove(BookInDb);
        _context.SaveChanges();
        return RedirectToAction("Books");  // deleting  the view, waitig to get Mariana name of the view

    }


    // here I am finding it Updating that Book
    public IActionResult UpdateBook(int id)
    {
        if (id != null)
        {

            var BookInDb = _context.Books.SingleOrDefault(b => b.Id == id);
            return View(BookInDb);
        }
        return RedirectToAction("Books");
    }

    // here showing The form of the book
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
            return View(model);
        }
        return View(); //adentro va la vista de los todos los libros.
    }


}