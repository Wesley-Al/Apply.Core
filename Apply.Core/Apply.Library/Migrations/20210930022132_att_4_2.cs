using Microsoft.EntityFrameworkCore.Migrations;

namespace Intru.Library.Migrations
{
    public partial class att_4_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Card",
                newName: "Time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Card",
                newName: "Date");
        }
    }
}
