using Microsoft.EntityFrameworkCore.Migrations;

namespace api_movil.Migrations
{
    public partial class FixColumPresentation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPresentation_Categories_PresentationsCategoryId",
                table: "CategoryPresentation");

            migrationBuilder.RenameColumn(
                name: "PresentationsCategoryId",
                table: "CategoryPresentation",
                newName: "CategoriesCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPresentation_Categories_CategoriesCategoryId",
                table: "CategoryPresentation",
                column: "CategoriesCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPresentation_Categories_CategoriesCategoryId",
                table: "CategoryPresentation");

            migrationBuilder.RenameColumn(
                name: "CategoriesCategoryId",
                table: "CategoryPresentation",
                newName: "PresentationsCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPresentation_Categories_PresentationsCategoryId",
                table: "CategoryPresentation",
                column: "PresentationsCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
