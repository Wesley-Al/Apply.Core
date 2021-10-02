using Microsoft.EntityFrameworkCore.Migrations;

namespace Intru.Library.Migrations
{
    public partial class att_5_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCadatro",
                table: "CategoryCard",
                newName: "CCDataCadatro");

            migrationBuilder.RenameColumn(
                name: "CategoryCardName",
                table: "CategoryCard",
                newName: "CCName");

            migrationBuilder.AddColumn<bool>(
                name: "CCTypeFixed",
                table: "CategoryCard",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CCTypeFixed",
                table: "CategoryCard");

            migrationBuilder.RenameColumn(
                name: "CCName",
                table: "CategoryCard",
                newName: "CategoryCardName");

            migrationBuilder.RenameColumn(
                name: "CCDataCadatro",
                table: "CategoryCard",
                newName: "DataCadatro");
        }
    }
}
