﻿// <auto-generated />
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStore.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookStore.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorName = "Stephen King",
                            CategoryId = 1,
                            ISBN = "978-1982112394",
                            NumberOfPages = 416,
                            Price = 19.58m,
                            Title = "Pet Semetary"
                        },
                        new
                        {
                            BookId = 2,
                            AuthorName = "Karen Marie Moning",
                            CategoryId = 2,
                            ISBN = "978-0440244400",
                            NumberOfPages = 498,
                            Price = 12.48m,
                            Title = "Dreamfever"
                        },
                        new
                        {
                            BookId = 3,
                            AuthorName = "Patricia Cornwell",
                            CategoryId = 3,
                            ISBN = "",
                            NumberOfPages = 287,
                            Price = 8.99m,
                            Title = "Postmortem"
                        },
                        new
                        {
                            BookId = 4,
                            AuthorName = "Mathew McConaughey",
                            CategoryId = 1,
                            ISBN = "978-0593139134",
                            NumberOfPages = 304,
                            Price = 18m,
                            Title = "Greenlights"
                        },
                        new
                        {
                            BookId = 5,
                            AuthorName = "Garth Williams",
                            CategoryId = 1,
                            ISBN = "",
                            NumberOfPages = 192,
                            Price = 6.4m,
                            Title = "Charlotte's Web"
                        },
                        new
                        {
                            BookId = 6,
                            AuthorName = "Jess Lourey",
                            CategoryId = 2,
                            ISBN = "978-1542016315",
                            NumberOfPages = 347,
                            Price = 11.99m,
                            Title = "Bloodline"
                        },
                        new
                        {
                            BookId = 7,
                            AuthorName = "John Grisham",
                            CategoryId = 2,
                            ISBN = "978-0525620945",
                            NumberOfPages = 448,
                            Price = 7.48m,
                            Title = "The Guardians"
                        },
                        new
                        {
                            BookId = 8,
                            AuthorName = "Lucy Foley",
                            CategoryId = 3,
                            ISBN = "",
                            NumberOfPages = 319,
                            Price = 14.99m,
                            Title = "The Guest List"
                        },
                        new
                        {
                            BookId = 9,
                            AuthorName = "J.K. Rowling",
                            CategoryId = 3,
                            ISBN = "",
                            NumberOfPages = 3423,
                            Price = 62.99m,
                            Title = "Harry Potter The Complete Collection"
                        },
                        new
                        {
                            BookId = 10,
                            AuthorName = "Nicholas Sparks",
                            CategoryId = 3,
                            ISBN = "",
                            NumberOfPages = 369,
                            Price = 11.99m,
                            Title = "The Return"
                        });
                });

            modelBuilder.Entity("BookStore.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "HardBack"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "PaperBack"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Digital"
                        });
                });

            modelBuilder.Entity("BookStore.Models.Book", b =>
                {
                    b.HasOne("BookStore.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
