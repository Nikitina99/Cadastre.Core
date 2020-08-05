using Microsoft.EntityFrameworkCore.Migrations;

namespace Cadastre.Core.DataAccess.Migrations
{
    public partial class AddColumnClientIsBlockListed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBlackListed",
                table: "Clients",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlackListed",
                table: "Clients");
        }
    }
}
