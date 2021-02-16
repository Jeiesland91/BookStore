using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class InitialDatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(nullable: false),
                    AuthorName = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    NumberOfPages = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 1, "HardBack" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 2, "PaperBack" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 3, "Digital" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorName", "CategoryId", "ISBN", "NumberOfPages", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Stephen King", 1, "978-1982112394", 416, 19.58m, "Pet Semetary" },
                    { 4, "Mathew McConaughey", 1, "978-0593139134", 304, 18m, "Greenlights" },
                    { 5, "Garth Williams", 1, "", 192, 6.4m, "Charlotte's Web" },
                    { 2, "Karen Marie Moning", 2, "978-0440244400", 498, 12.48m, "Dreamfever" },
                    { 6, "Jess Lourey", 2, "978-1542016315", 347, 11.99m, "Bloodline" },
                    { 7, "John Grisham", 2, "978-0525620945", 448, 7.48m, "The Guardians" },
                    { 3, "Patricia Cornwell", 3, "", 287, 8.99m, "Postmortem" },
                    { 8, "Lucy Foley", 3, "", 319, 14.99m, "The Guest List" },
                    { 9, "J.K. Rowling", 3, "", 3423, 62.99m, "Harry Potter The Complete Collection" },
                    { 10, "Nicholas Sparks", 3, "", 369, 11.99m, "The Return" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
