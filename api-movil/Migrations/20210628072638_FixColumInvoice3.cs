using Microsoft.EntityFrameworkCore.Migrations;

namespace api_movil.Migrations
{
    public partial class FixColumInvoice3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceIdInvoice",
                table: "InvoiceDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "InvoiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ProductId",
                table: "InvoiceDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Products_ProductId",
                table: "InvoiceDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Products_ProductId",
                table: "InvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_ProductId",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "InvoiceIdInvoice",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
