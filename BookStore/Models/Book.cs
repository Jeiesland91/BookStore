using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Book
    {
        // EF will instruct the database to automatically generate this value
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter ISBN Number.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Please enter author name.")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Please enter title of book.")]
        public string Title { get; set; }

        public int NumberOfPages { get; set; }

        [Required(ErrorMessage = "Please enter price of book.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }  // foreign key property
        public Category Category { get; set; }

        public string Slug
        {
            get
            {
                if (AuthorName == null)
                    return "";
                else
                    return AuthorName.Replace(' ', '-');
            }
        }
    }
}
