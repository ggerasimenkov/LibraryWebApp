using Microsoft.AspNetCore.Mvc;
using LibraryWebApp.Data;
using LibraryWebApp.Models;
using System.Linq;

namespace LibraryWebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _context;

        public BookController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}