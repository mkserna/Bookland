using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookland.Models;

public class BookController: Controller
{
    private readonly ILogger<BookController>_logger;

    private readonly BookDbContext  Context;

    public BookController(ILogger<BookController>logger, BookDbContext context)
    {
        _logger = logger;
        _context = context;
    }

     public IActionResult Index()
    {
        return View();
    }

    //Todos  los libros View

    public IActionResult books()// revisar que considad con la vista de libros 
    {
         var allBooks = _context.vistadelibros.Tolist();
         return View(allBooks);
    }

    //para Eliminar 

}