using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP2.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "movies",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "genres",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "movies",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "genres",
                newName: "name");
        }
    }
}
