using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intru.Library.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    CodBank = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBank = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.CodBank);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    CodWallet = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodBank = table.Column<long>(type: "bigint", nullable: false),
                    BankNavigationCodBank = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.CodWallet);
                    table.ForeignKey(
                        name: "FK_Wallet_Banks_BankNavigationCodBank",
                        column: x => x.BankNavigationCodBank,
                        principalTable: "Banks",
                        principalColumn: "CodBank",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    CodUsuario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodWallet = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioLogin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletNavigationCodWallet = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.CodUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Wallet_WalletNavigationCodWallet",
                        column: x => x.WalletNavigationCodWallet,
                        principalTable: "Wallet",
                        principalColumn: "CodWallet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryCard",
                columns: table => new
                {
                    CCCod = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CCName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CCTypeFixed = table.Column<bool>(type: "bit", nullable: false),
                    CCDataCadatro = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "UsuarioWallet",
                columns: table => new
                {
                    UWCod = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodUsuario1 = table.Column<long>(type: "bigint", nullable: true),
                    CodWallet1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioWallet", x => x.UWCod);
                    table.ForeignKey(
                        name: "FK_UsuarioWallet_Usuario_CodUsuario1",
                        column: x => x.CodUsuario1,
                        principalTable: "Usuario",
                        principalColumn: "CodUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioWallet_Wallet_CodWallet1",
                        column: x => x.CodWallet1,
                        principalTable: "Wallet",
                        principalColumn: "CodWallet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CodCard = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotPayment = table.Column<bool>(type: "bit", nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodWallet = table.Column<long>(type: "bigint", nullable: true),
                    WalletNavigationCodWallet = table.Column<long>(type: "bigint", nullable: true),
                    CodBank = table.Column<long>(type: "bigint", nullable: true),
                    BankNavigationCodBank = table.Column<long>(type: "bigint", nullable: true),
                    TypeCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryCardNavigationCCCod = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CodCard);
                    table.ForeignKey(
                        name: "FK_Card_Banks_BankNavigationCodBank",
                        column: x => x.BankNavigationCodBank,
                        principalTable: "Banks",
                        principalColumn: "CodBank",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Card_CategoryCard_CategoryCardNavigationCCCod",
                        column: x => x.CategoryCardNavigationCCCod,
                        principalTable: "CategoryCard",
                        principalColumn: "CCCod",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Card_Wallet_WalletNavigationCodWallet",
                        column: x => x.WalletNavigationCodWallet,
                        principalTable: "Wallet",
                        principalColumn: "CodWallet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_BankNavigationCodBank",
                table: "Card",
                column: "BankNavigationCodBank");

            migrationBuilder.CreateIndex(
                name: "IX_Card_CategoryCardNavigationCCCod",
                table: "Card",
                column: "CategoryCardNavigationCCCod");

            migrationBuilder.CreateIndex(
                name: "IX_Card_WalletNavigationCodWallet",
                table: "Card",
                column: "WalletNavigationCodWallet");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCard_UsuarioNavigationCodUsuario",
                table: "CategoryCard",
                column: "UsuarioNavigationCodUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_WalletNavigationCodWallet",
                table: "Usuario",
                column: "WalletNavigationCodWallet");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioWallet_CodUsuario1",
                table: "UsuarioWallet",
                column: "CodUsuario1");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioWallet_CodWallet1",
                table: "UsuarioWallet",
                column: "CodWallet1");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_BankNavigationCodBank",
                table: "Wallet",
                column: "BankNavigationCodBank");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "UsuarioWallet");

            migrationBuilder.DropTable(
                name: "CategoryCard");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
