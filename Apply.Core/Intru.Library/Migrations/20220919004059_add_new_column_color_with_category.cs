using Microsoft.EntityFrameworkCore.Migrations;

namespace Intru.Library.Migrations
{
    public partial class add_new_column_color_with_category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CategoryCard",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "CategoryCard");
        }
    }
}
