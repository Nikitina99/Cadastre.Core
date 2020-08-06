using Microsoft.EntityFrameworkCore.Migrations;

namespace Cadastre.Core.DataAccess.Migrations
{
    public partial class UpdateColumnClientIsBlockListed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsBlackListed",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsBlackListed",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
