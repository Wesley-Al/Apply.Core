﻿// <auto-generated />
using System;
using Intru.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Intru.Library.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210930020614_att_4.0")]
    partial class att_40
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("Intru.Library.Bank", b =>
                {
                    b.Property<long>("CodBank")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("NameBank")
                        .HasColumnType("longtext");

                    b.HasKey("CodBank");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("Intru.Library.Cards", b =>
                {
                    b.Property<long?>("CodCard")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Amount")
                        .HasColumnType("longtext");

                    b.Property<long?>("BankNavigationCodBank")
                        .HasColumnType("bigint");

                    b.Property<long?>("CategoryCardNavigationCCCod")
                        .HasColumnType("bigint");

                    b.Property<long>("CodBank")
                        .HasColumnType("bigint");

                    b.Property<long>("CodWallet")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool>("NotPayment")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TimeString")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.Property<string>("TypeCard")
                        .HasColumnType("longtext");

                    b.Property<long?>("WalletNavigationCodWallet")
                        .HasColumnType("bigint");

                    b.HasKey("CodCard");

                    b.HasIndex("BankNavigationCodBank");

                    b.HasIndex("CategoryCardNavigationCCCod");

                    b.HasIndex("WalletNavigationCodWallet");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("Intru.Library.CategoryCard", b =>
                {
                    b.Property<long>("CCCod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CategoryCardName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataCadatro")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("UsuarioNavigationCodUsuario")
                        .HasColumnType("bigint");

                    b.HasKey("CCCod");

                    b.HasIndex("UsuarioNavigationCodUsuario");

                    b.ToTable("CategoryCard");
                });

            modelBuilder.Entity("Intru.Library.Usuario", b =>
                {
                    b.Property<long>("CodUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("CodWallet")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomeUsuario")
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext");

                    b.Property<string>("UsuarioLogin")
                        .HasColumnType("longtext");

                    b.Property<long?>("WalletNavigationCodWallet")
                        .HasColumnType("bigint");

                    b.HasKey("CodUsuario");

                    b.HasIndex("WalletNavigationCodWallet");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Intru.Library.UsuarioWallet", b =>
                {
                    b.Property<long>("UWCod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CodUsuario1")
                        .HasColumnType("bigint");

                    b.Property<long?>("CodWallet1")
                        .HasColumnType("bigint");

                    b.HasKey("UWCod");

                    b.HasIndex("CodUsuario1");

                    b.HasIndex("CodWallet1");

                    b.ToTable("UsuarioWallet");
                });

            modelBuilder.Entity("Intru.Library.Wallet", b =>
                {
                    b.Property<long>("CodWallet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("BankNavigationCodBank")
                        .HasColumnType("bigint");

                    b.Property<long>("CodBank")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime(6)");

                    b.HasKey("CodWallet");

                    b.HasIndex("BankNavigationCodBank");

                    b.ToTable("Wallet");
                });

            modelBuilder.Entity("Intru.Library.Cards", b =>
                {
                    b.HasOne("Intru.Library.Bank", "BankNavigation")
                        .WithMany()
                        .HasForeignKey("BankNavigationCodBank");

                    b.HasOne("Intru.Library.CategoryCard", "CategoryCardNavigation")
                        .WithMany()
                        .HasForeignKey("CategoryCardNavigationCCCod");

                    b.HasOne("Intru.Library.Wallet", "WalletNavigation")
                        .WithMany()
                        .HasForeignKey("WalletNavigationCodWallet");

                    b.Navigation("BankNavigation");

                    b.Navigation("CategoryCardNavigation");

                    b.Navigation("WalletNavigation");
                });

            modelBuilder.Entity("Intru.Library.CategoryCard", b =>
                {
                    b.HasOne("Intru.Library.Usuario", "UsuarioNavigation")
                        .WithMany()
                        .HasForeignKey("UsuarioNavigationCodUsuario");

                    b.Navigation("UsuarioNavigation");
                });

            modelBuilder.Entity("Intru.Library.Usuario", b =>
                {
                    b.HasOne("Intru.Library.Wallet", "WalletNavigation")
                        .WithMany()
                        .HasForeignKey("WalletNavigationCodWallet");

                    b.Navigation("WalletNavigation");
                });

            modelBuilder.Entity("Intru.Library.UsuarioWallet", b =>
                {
                    b.HasOne("Intru.Library.Usuario", "CodUsuario")
                        .WithMany()
                        .HasForeignKey("CodUsuario1");

                    b.HasOne("Intru.Library.Wallet", "CodWallet")
                        .WithMany()
                        .HasForeignKey("CodWallet1");

                    b.Navigation("CodUsuario");

                    b.Navigation("CodWallet");
                });

            modelBuilder.Entity("Intru.Library.Wallet", b =>
                {
                    b.HasOne("Intru.Library.Bank", "BankNavigation")
                        .WithMany()
                        .HasForeignKey("BankNavigationCodBank");

                    b.Navigation("BankNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
