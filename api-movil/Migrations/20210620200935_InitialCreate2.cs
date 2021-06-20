using Microsoft.EntityFrameworkCore.Migrations;

namespace api_movil.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_User_UserName",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_UserName",
                table: "Clients",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_UserName",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_User_UserName",
                table: "Clients",
                column: "UserName",
                principalTable: "User",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
