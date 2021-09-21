﻿// <auto-generated />
using System;
using Apply.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Apply.Library.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210905203021_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Apply.Library.Bank", b =>
                {
                    b.Property<long>("CodBank")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("NameBank")
                        .HasColumnType("longtext");

                    b.HasKey("CodBank");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("Apply.Library.Cards", b =>
                {
                    b.Property<long?>("CodCard")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Amount")
                        .HasColumnType("longtext");

                    b.Property<long?>("BankNavigationCodBank")
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

                    b.Property<long?>("WalletNavigationCodWallet")
                        .HasColumnType("bigint");

                    b.HasKey("CodCard");

                    b.HasIndex("BankNavigationCodBank");

                    b.HasIndex("WalletNavigationCodWallet");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("Apply.Library.FlowClosed", b =>
                {
                    b.Property<long>("CodFlowClosed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Amount")
                        .HasColumnType("longtext");

                    b.Property<long?>("BankNavigationCodBank")
                        .HasColumnType("bigint");

                    b.Property<long>("CodBank")
                        .HasColumnType("bigint");

                    b.Property<long>("CodWallet")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TimeString")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<long?>("WalletNavigationCodWallet")
                        .HasColumnType("bigint");

                    b.HasKey("CodFlowClosed");

                    b.HasIndex("BankNavigationCodBank");

                    b.HasIndex("WalletNavigationCodWallet");

                    b.ToTable("FlowClosed");
                });

            modelBuilder.Entity("Apply.Library.Payment", b =>
                {
                    b.Property<long>("CodPayment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Amount")
                        .HasColumnType("longtext");

                    b.Property<long?>("BankNavigationCodBank")
                        .HasColumnType("bigint");

                    b.Property<long>("CodBank")
                        .HasColumnType("bigint");

                    b.Property<long>("CodWallet")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TimeString")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<long?>("WalletNavigationCodWallet")
                        .HasColumnType("bigint");

                    b.HasKey("CodPayment");

                    b.HasIndex("BankNavigationCodBank");

                    b.HasIndex("WalletNavigationCodWallet");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Apply.Library.Usuario", b =>
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

            modelBuilder.Entity("Apply.Library.UsuarioWallet", b =>
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

            modelBuilder.Entity("Apply.Library.Wallet", b =>
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

            modelBuilder.Entity("Apply.Library.Cards", b =>
                {
                    b.HasOne("Apply.Library.Bank", "BankNavigation")
                        .WithMany()
                        .HasForeignKey("BankNavigationCodBank");

                    b.HasOne("Apply.Library.Wallet", "WalletNavigation")
                        .WithMany()
                        .HasForeignKey("WalletNavigationCodWallet");

                    b.Navigation("BankNavigation");

                    b.Navigation("WalletNavigation");
                });

            modelBuilder.Entity("Apply.Library.FlowClosed", b =>
                {
                    b.HasOne("Apply.Library.Bank", "BankNavigation")
                        .WithMany()
                        .HasForeignKey("BankNavigationCodBank");

                    b.HasOne("Apply.Library.Wallet", "WalletNavigation")
                        .WithMany()
                        .HasForeignKey("WalletNavigationCodWallet");

                    b.Navigation("BankNavigation");

                    b.Navigation("WalletNavigation");
                });

            modelBuilder.Entity("Apply.Library.Payment", b =>
                {
                    b.HasOne("Apply.Library.Bank", "BankNavigation")
                        .WithMany()
                        .HasForeignKey("BankNavigationCodBank");

                    b.HasOne("Apply.Library.Wallet", "WalletNavigation")
                        .WithMany()
                        .HasForeignKey("WalletNavigationCodWallet");

                    b.Navigation("BankNavigation");

                    b.Navigation("WalletNavigation");
                });

            modelBuilder.Entity("Apply.Library.Usuario", b =>
                {
                    b.HasOne("Apply.Library.Wallet", "WalletNavigation")
                        .WithMany()
                        .HasForeignKey("WalletNavigationCodWallet");

                    b.Navigation("WalletNavigation");
                });

            modelBuilder.Entity("Apply.Library.UsuarioWallet", b =>
                {
                    b.HasOne("Apply.Library.Usuario", "CodUsuario")
                        .WithMany()
                        .HasForeignKey("CodUsuario1");

                    b.HasOne("Apply.Library.Wallet", "CodWallet")
                        .WithMany()
                        .HasForeignKey("CodWallet1");

                    b.Navigation("CodUsuario");

                    b.Navigation("CodWallet");
                });

            modelBuilder.Entity("Apply.Library.Wallet", b =>
                {
                    b.HasOne("Apply.Library.Bank", "BankNavigation")
                        .WithMany()
                        .HasForeignKey("BankNavigationCodBank");

                    b.Navigation("BankNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
