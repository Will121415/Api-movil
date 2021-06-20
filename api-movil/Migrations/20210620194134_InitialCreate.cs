using Microsoft.EntityFrameworkCore.Migrations;

namespace api_movil.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Presentations",
                columns: table => new
                {
                    PresentationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Measure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPresentation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentations", x => x.PresentationId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityStock = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesPresentations",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    PresentationsPresentationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesPresentations", x => new { x.CategoriesCategoryId, x.PresentationsPresentationId });
                    table.ForeignKey(
                        name: "FK_CategoriesPresentations_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesPresentations_Presentations_PresentationsPresentationId",
                        column: x => x.PresentationsPresentationId,
                        principalTable: "Presentations",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Indentification = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(130)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Neighborhood = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Indentification);
                    table.ForeignKey(
                        name: "FK_Clients_User_UserName",
                        column: x => x.UserName,
                        principalTable: "User",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesPresentations_PresentationsPresentationId",
                table: "CategoriesPresentations",
                column: "PresentationsPresentationId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserName",
                table: "Clients",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesPresentations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Presentations");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
