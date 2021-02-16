using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private StoreContext context;

        public BookController(StoreContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Book");
        }

        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            var categories = context.Categories
                .OrderBy(c => c.CategoryId).ToList();

            List<Book> Books;
            if (id == "All")
            {
                Books = context.Books
                    .OrderBy(p => p.BookId).ToList();
            }
            else
            {
                Books = context.Books
                    .Include(c => c.Category)
                    .Where(p => p.Category.Name == id)
                    .OrderBy(p => p.BookId).ToList();
            }

            // use ViewBag to pass data to view
            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;
    
            // bind Books to view
            return View(Books);
        }

        public IActionResult Details(int id)
        {
            var categories = context.Categories
                .OrderBy(c => c.CategoryId).ToList();

            Book Book = context.Books.Find(id);

            // use ViewBag to pass data to view
            ViewBag.Categories = categories;
      
            // bind Book to view
            return View(Book);
        }
    }
}
