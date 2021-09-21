﻿// <auto-generated />
using System;
using Apply.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Apply.Core.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210814013857_Att_7")]
    partial class Att_7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Apply.Library.Bank", b =>
                {
                    b.Property<long>("CodBank")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameBank")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodBank");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("Apply.Library.Cards", b =>
                {
                    b.Property<long?>("CodCard")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("BankNavigationCodBank")
                        .HasColumnType("bigint");

                    b.Property<long>("CodBank")
                        .HasColumnType("bigint");

                    b.Property<long>("CodWallet")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NotPayment")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("TimeString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("BankNavigationCodBank")
                        .HasColumnType("bigint");

                    b.Property<long>("CodBank")
                        .HasColumnType("bigint");

                    b.Property<long>("CodWallet")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("TimeString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("BankNavigationCodBank")
                        .HasColumnType("bigint");

                    b.Property<long>("CodBank")
                        .HasColumnType("bigint");

                    b.Property<long>("CodWallet")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("TimeString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CodWallet")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("WalletNavigationCodWallet")
                        .HasColumnType("bigint");

                    b.HasKey("CodUsuario");

                    b.HasIndex("WalletNavigationCodWallet");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Apply.Library.Wallet", b =>
                {
                    b.Property<long>("CodWallet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BankNavigationCodBank")
                        .HasColumnType("bigint");

                    b.Property<long>("CodBank")
                        .HasColumnType("bigint");

                    b.Property<int>("CodCards")
                        .HasColumnType("int");

                    b.Property<int>("CodFlowClosed")
                        .HasColumnType("int");

                    b.Property<int>("CodPayment")
                        .HasColumnType("int");

                    b.Property<int>("CodUsuario")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

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
                        .WithMany("CardsNavigation")
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
                        .WithMany("FlowClosedNavigation")
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
                        .WithMany("PaymentNavigation")
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

            modelBuilder.Entity("Apply.Library.Wallet", b =>
                {
                    b.HasOne("Apply.Library.Bank", "BankNavigation")
                        .WithMany()
                        .HasForeignKey("BankNavigationCodBank");

                    b.Navigation("BankNavigation");
                });

            modelBuilder.Entity("Apply.Library.Wallet", b =>
                {
                    b.Navigation("CardsNavigation");

                    b.Navigation("FlowClosedNavigation");

                    b.Navigation("PaymentNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
