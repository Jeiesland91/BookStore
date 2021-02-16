using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "HardBack" },
                new Category { CategoryId = 2, Name = "PaperBack" },
                new Category { CategoryId = 3, Name = "Digital" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    CategoryId = 1,
                    ISBN = "978-1982112394",
                    AuthorName = "Stephen King",
                    Title = "Pet Semetary",
                    NumberOfPages = 416,
                    Price = (decimal)19.58
                },
                new Book
                {
                    BookId = 2,
                    CategoryId = 2,
                    ISBN = "978-0440244400",
                    AuthorName = "Karen Marie Moning",
                    Title = "Dreamfever",
                    NumberOfPages = 498,
                    Price = (decimal)12.48
                },
                new Book
                {
                    BookId = 3,
                    CategoryId = 3,
                    ISBN = string.Empty,
                    AuthorName = "Patricia Cornwell",
                    Title = "Postmortem",
                    NumberOfPages = 287,
                    Price = (decimal)8.99
                },
                new Book
                {
                    BookId = 4,
                    CategoryId = 1,
                    ISBN = "978-0593139134",
                    AuthorName = "Mathew McConaughey",
                    Title = "Greenlights",
                    NumberOfPages = 304,
                    Price = (decimal)18.00
                },
                new Book
                {
                    BookId = 5,
                    CategoryId = 1,
                    ISBN = "",
                    AuthorName = "Garth Williams",
                    Title = "Charlotte's Web",
                    NumberOfPages = 192,
                    Price = (decimal)6.40
                },
                new Book
                {
                    BookId = 6,
                    CategoryId = 2,
                    ISBN = "978-1542016315",
                    AuthorName = "Jess Lourey",
                    Title = "Bloodline",
                    NumberOfPages = 347,
                    Price = (decimal)11.99
                },
                new Book
                {
                    BookId = 7,
                    CategoryId = 2,
                    ISBN = "978-0525620945",
                    AuthorName = "John Grisham",
                    Title = "The Guardians",
                    NumberOfPages = 448,
                    Price = (decimal)7.48
                },
                new Book
                {
                    BookId = 8,
                    CategoryId = 3,
                    ISBN = "",
                    AuthorName = "Lucy Foley",
                    Title = "The Guest List",
                    NumberOfPages = 319,
                    Price = (decimal)14.99
                },
                new Book
                {
                    BookId = 9,
                    CategoryId = 3,
                    ISBN = "",
                    AuthorName = "J.K. Rowling",
                    Title = "Harry Potter The Complete Collection",
                    NumberOfPages = 3423,
                    Price = (decimal)62.99
                },
                new Book
                {
                    BookId = 10,
                    CategoryId = 3,
                    ISBN = "",
                    AuthorName = "Nicholas Sparks",
                    Title = "The Return",
                    NumberOfPages = 369,
                    Price = (decimal)11.99
                }
            );
        }
    }
}
