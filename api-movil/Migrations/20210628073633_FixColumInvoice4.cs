using Microsoft.EntityFrameworkCore.Migrations;

namespace api_movil.Migrations
{
    public partial class FixColumInvoice4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceIdInvoice",
                table: "InvoiceDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvoiceIdInvoice",
                table: "InvoiceDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
