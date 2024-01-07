﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreFIAP.Repository;

#nullable disable

namespace Play_investe.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Play_investe.Entity.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR(50)")
                        .HasDefaultValue("Conta Corrente");

                    b.Property<string>("Agency")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR(10)")
                        .HasDefaultValue("0024");

                    b.Property<double>("Balance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("FLOAT")
                        .HasDefaultValue(0.0);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("DesactivedDate")
                        .IsRequired()
                        .HasColumnType("DATETIME");

                    b.Property<int>("IdUser")
                        .HasColumnType("INT");

                    b.Property<bool>("IsWithdrawalAvailableForAll")
                        .HasColumnType("BIT");

                    b.Property<double>("TotalInvestimentValue")
                        .HasColumnType("FLOAT");

                    b.Property<DateTime?>("UpdatedDate")
                        .IsRequired()
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("WithdrawalAvailabilityDate")
                        .HasColumnType("DATETIME");

                    b.Property<double>("WithdrawalAvailableAmount")
                        .HasColumnType("FLOAT");

                    b.HasKey("Id");

                    b.HasIndex("IdUser")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Play_investe.Entity.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("DesactivedDate")
                        .IsRequired()
                        .HasColumnType("DATETIME");

                    b.Property<int>("IdUser")
                        .HasColumnType("INT");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .IsRequired()
                        .HasColumnType("DATETIME");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdUser")
                        .IsUnique();

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("Play_investe.Entity.Bound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AvailableForWithdrawal")
                        .HasColumnType("BIT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("DesactivedDate")
                        .IsRequired()
                        .HasColumnType("DATETIME");

                    b.Property<double>("Index")
                        .HasColumnType("FLOAT");

                    b.Property<int>("LiquidityType")
                        .HasColumnType("int");

                    b.Property<double>("Percent")
                        .HasColumnType("FLOAT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .IsRequired()
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.ToTable("Bound", (string)null);
                });

            modelBuilder.Entity("Play_investe.Entity.Investment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<DateTime>("AquisitionDate")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("DesactivedDate")
                        .IsRequired()
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("DATETIME");

                    b.Property<int>("IdAccount")
                        .HasColumnType("INT");

                    b.Property<int>("IdBound")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .IsRequired()
                        .HasColumnType("DATETIME");

                    b.Property<decimal>("Value")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdAccount");

                    b.HasIndex("IdBound");

                    b.ToTable("Investment", (string)null);
                });

            modelBuilder.Entity("Play_investe.Entity.TransactionsBank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("FLOAT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("DesactivedDate")
                        .IsRequired()
                        .HasColumnType("DATETIME");

                    b.Property<int>("DestinationAccountId")
                        .HasColumnType("INT");

                    b.Property<int>("IdAccount")
                        .HasColumnType("INT");

                    b.Property<int>("SourceAccountId")
                        .HasColumnType("INT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .IsRequired()
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.HasIndex("IdAccount");

                    b.ToTable("TransactionsBank", (string)null);
                });

            modelBuilder.Entity("StoreFIAP.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("DesactivedDate")
                        .IsRequired()
                        .HasColumnType("DATETIME");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<bool>("IsActived")
                        .HasColumnType("BIT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Permitions")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<DateTime?>("UpdatedDate")
                        .IsRequired()
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Play_investe.Entity.Account", b =>
                {
                    b.HasOne("StoreFIAP.Entity.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("Play_investe.Entity.Account", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Play_investe.Entity.Address", b =>
                {
                    b.HasOne("StoreFIAP.Entity.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("Play_investe.Entity.Address", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Play_investe.Entity.Investment", b =>
                {
                    b.HasOne("Play_investe.Entity.Account", "Account")
                        .WithMany("Investments")
                        .HasForeignKey("IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Play_investe.Entity.Bound", "Bound")
                        .WithMany("Investments")
                        .HasForeignKey("IdBound")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Bound");
                });

            modelBuilder.Entity("Play_investe.Entity.TransactionsBank", b =>
                {
                    b.HasOne("Play_investe.Entity.Account", "Account")
                        .WithMany("TransactionsBank")
                        .HasForeignKey("IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Play_investe.Entity.Account", b =>
                {
                    b.Navigation("Investments");

                    b.Navigation("TransactionsBank");
                });

            modelBuilder.Entity("Play_investe.Entity.Bound", b =>
                {
                    b.Navigation("Investments");
                });

            modelBuilder.Entity("StoreFIAP.Entity.User", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("Address")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
