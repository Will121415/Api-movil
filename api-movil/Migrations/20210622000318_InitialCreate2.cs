using Microsoft.EntityFrameworkCore.Migrations;

namespace api_movil.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NPresentation",
                table: "Presentations",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Presentations",
                newName: "NPresentation");
        }
    }
}
