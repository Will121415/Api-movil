using Microsoft.EntityFrameworkCore.Migrations;

namespace api_movil.Migrations
{
    public partial class FixRelacionCategoriaPrese : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presentations_Categories_CategoriesCategoryId",
                table: "Presentations");

            migrationBuilder.DropIndex(
                name: "IX_Presentations_CategoriesCategoryId",
                table: "Presentations");

            migrationBuilder.DropColumn(
                name: "CategoriesCategoryId",
                table: "Presentations");

            migrationBuilder.CreateTable(
                name: "CategoryPresentation",
                columns: table => new
                {
                    PresentationsCategoryId = table.Column<int>(type: "int", nullable: false),
                    PresentationsPresentationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPresentation", x => new { x.PresentationsCategoryId, x.PresentationsPresentationId });
                    table.ForeignKey(
                        name: "FK_CategoryPresentation_Categories_PresentationsCategoryId",
                        column: x => x.PresentationsCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPresentation_Presentations_PresentationsPresentationId",
                        column: x => x.PresentationsPresentationId,
                        principalTable: "Presentations",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPresentation_PresentationsPresentationId",
                table: "CategoryPresentation",
                column: "PresentationsPresentationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryPresentation");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesCategoryId",
                table: "Presentations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presentations_CategoriesCategoryId",
                table: "Presentations",
                column: "CategoriesCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Presentations_Categories_CategoriesCategoryId",
                table: "Presentations",
                column: "CategoriesCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
