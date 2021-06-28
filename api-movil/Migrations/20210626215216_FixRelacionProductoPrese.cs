using Microsoft.EntityFrameworkCore.Migrations;

namespace api_movil.Migrations
{
    public partial class FixRelacionProductoPrese : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presentations_Products_ProductId",
                table: "Presentations");

            migrationBuilder.DropIndex(
                name: "IX_Presentations_ProductId",
                table: "Presentations");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Presentations");

            migrationBuilder.CreateTable(
                name: "PresentationProduct",
                columns: table => new
                {
                    PresentationsPresentationId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentationProduct", x => new { x.PresentationsPresentationId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_PresentationProduct_Presentations_PresentationsPresentationId",
                        column: x => x.PresentationsPresentationId,
                        principalTable: "Presentations",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresentationProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PresentationProduct_ProductsProductId",
                table: "PresentationProduct",
                column: "ProductsProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresentationProduct");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Presentations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presentations_ProductId",
                table: "Presentations",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Presentations_Products_ProductId",
                table: "Presentations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
