using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private StoreContext context;
        private List<Category> categories;

        public BookController(StoreContext ctx)
        {
            context = ctx;
            categories = context.Categories
                    .OrderBy(c => c.CategoryId)
                    .ToList();
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            List<Book> Books;
            if (id == "All")
            {
                Books = context.Books
                    .OrderBy(p => p.BookId).ToList();
            }
            else
            {
                Books = context.Books
                    .Where(p => p.Category.Name == id)
                    .OrderBy(p => p.BookId).ToList();
            }

            // use ViewBag to pass category data to view
            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;

            // bind Books to view
            return View(Books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // create new Book object
            Book Book = new Book();                // create Book object
            Book.Category = context.Categories.Find(1);  // add Category object - prevents validation problem

            // use ViewBag to pass action and category data to view
            ViewBag.Action = "Add";
            ViewBag.Categories = categories;

            // bind Book to AddUpdate view
            return View("AddUpdate", Book);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            // get Book object for specified primary key
            Book Book = context.Books
                .Include(p => p.Category)
                .FirstOrDefault(p => p.BookId == id);

            // use ViewBag to pass action and category data to view
            ViewBag.Action = "Update";
            ViewBag.Categories = categories;

            // bind Book to AddUpdate view
            return View("AddUpdate", Book);
        }

        [HttpPost]
        public IActionResult Update(Book Book)
        {
            if (ModelState.IsValid)
            {
                if (Book.BookId == 0)           // new Book
                {
                    context.Books.Add(Book);
                }
                else                                  // existing Book
                {
                    context.Books.Update(Book);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                ViewBag.Categories = categories;
                return View("AddUpdate", Book);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Book Book = context.Books
                .FirstOrDefault(p => p.BookId == id);
            return View(Book);
        }

        [HttpPost]
        public IActionResult Delete(Book Book)
        {
            context.Books.Remove(Book);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}