using LibraryWebApp.Data;
using LibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryWebApp.Controllers;

public class BookController : Controller
{
    private readonly LibraryContext _context;

    public BookController(LibraryContext context)
    {
        _context = context;
        if (!_context.Books.Any())
        {
            _context.Books.AddRange(
                new Book { Title = "Сияние", Author = "Стивен Кинг", Year = 1977 },
                new Book { Title = "Война и Мир", Author = "Лев Толстой", Year = 1869 },
                new Book { Title = "Мастер и Маргарита", Author = "М.А. Булгаков", Year = 1940 }
                );
            context.SaveChanges();
        }
    }

    public IActionResult Index()
    {
        var books = _context.Books.ToList();
        return View(books);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Book newBook)
    {
        if (ModelState.IsValid)
        {
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(newBook);
    }

    public IActionResult Edit(int? id)
    {
        var book = _context.Books.Find(id);
        if (book == null) return NotFound();
        return View(book);
    }

    [HttpPost]
    public IActionResult Edit(Book editedBook)
    {
        if (ModelState.IsValid)
        {
            _context.Books.Update(editedBook);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(editedBook);
    }

    public IActionResult Delete(int? id)
    {
        var book = _context.Books.Find(id);
        if (book == null) return NotFound();
        return View(book);
    }
    
    [HttpPost, ActionName("DeleteConfirmed")]
    public IActionResult DeleteConfirmed(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null) return NotFound();

        _context.Books.Remove(book);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
    public IActionResult Details(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null) return NotFound();
        return View(book);
    }


}