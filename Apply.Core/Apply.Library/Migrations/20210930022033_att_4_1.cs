using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intru.Library.Migrations
{
    public partial class att_4_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Card",
                newName: "DateRegistro");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Card",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Card");

            migrationBuilder.RenameColumn(
                name: "DateRegistro",
                table: "Card",
                newName: "Time");
        }
    }
}
