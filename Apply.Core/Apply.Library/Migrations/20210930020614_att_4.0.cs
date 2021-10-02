using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intru.Library.Migrations
{
    public partial class att_40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategoryCardNavigationCCCod",
                table: "Card",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Card",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoryCard",
                columns: table => new
                {
                    CCCod = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryCardName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCadatro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioNavigationCodUsuario = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCard", x => x.CCCod);
                    table.ForeignKey(
                        name: "FK_CategoryCard_Usuario_UsuarioNavigationCodUsuario",
                        column: x => x.UsuarioNavigationCodUsuario,
                        principalTable: "Usuario",
                        principalColumn: "CodUsuario",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Card_CategoryCardNavigationCCCod",
                table: "Card",
                column: "CategoryCardNavigationCCCod");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCard_UsuarioNavigationCodUsuario",
                table: "CategoryCard",
                column: "UsuarioNavigationCodUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_CategoryCard_CategoryCardNavigationCCCod",
                table: "Card",
                column: "CategoryCardNavigationCCCod",
                principalTable: "CategoryCard",
                principalColumn: "CCCod",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_CategoryCard_CategoryCardNavigationCCCod",
                table: "Card");

            migrationBuilder.DropTable(
                name: "CategoryCard");

            migrationBuilder.DropIndex(
                name: "IX_Card_CategoryCardNavigationCCCod",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "CategoryCardNavigationCCCod",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Card");
        }
    }
}
