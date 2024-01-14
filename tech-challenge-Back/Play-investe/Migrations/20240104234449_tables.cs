using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Play_investe.Migrations
{

    /// <inheritdoc />
    public partial class tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bound",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiquidityType = table.Column<int>(type: "int", nullable: false),
                    AvailableForWithdrawal = table.Column<bool>(type: "BIT", nullable: false),
                    Type = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Index = table.Column<double>(type: "FLOAT", nullable: false),
                    Percent = table.Column<double>(type: "FLOAT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DesactivedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bound", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    RG = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Permitions = table.Column<int>(type: "int", nullable: false),
                    IsActived = table.Column<bool>(type: "BIT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DesactivedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<double>(type: "FLOAT", nullable: false, defaultValue: 0.0),
                    Agency = table.Column<string>(type: "VARCHAR(10)", nullable: false, defaultValue: "0024"),
                    AccountNumber = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    AccountType = table.Column<string>(type: "VARCHAR(50)", nullable: false, defaultValue: "Conta Corrente"),
                    WithdrawalAvailabilityDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsWithdrawalAvailableForAll = table.Column<bool>(type: "BIT", nullable: false),
                    WithdrawalAvailableAmount = table.Column<double>(type: "FLOAT", nullable: false),
                    TotalInvestimentValue = table.Column<double>(type: "FLOAT", nullable: false),
                    IdUser = table.Column<int>(type: "INT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DesactivedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Number = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    ZipCode = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    City = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    State = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    IdUser = table.Column<int>(type: "INT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DesactivedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Investment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    AquisitionDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdAccount = table.Column<int>(type: "INT", nullable: false),
                    IdBound = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DesactivedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investment_Account_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Investment_Bound_IdBound",
                        column: x => x.IdBound,
                        principalTable: "Bound",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionsBank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Amount = table.Column<double>(type: "FLOAT", nullable: false),
                    Type = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    SourceAccountId = table.Column<int>(type: "INT", nullable: false),
                    DestinationAccountId = table.Column<int>(type: "INT", nullable: false),
                    IdAccount = table.Column<int>(type: "INT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DesactivedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionsBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionsBank_Account_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_IdUser",
                table: "Account",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_IdUser",
                table: "Address",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Investment_IdAccount",
                table: "Investment",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Investment_IdBound",
                table: "Investment",
                column: "IdBound");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsBank_IdAccount",
                table: "TransactionsBank",
                column: "IdAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Investment");

            migrationBuilder.DropTable(
                name: "TransactionsBank");

            migrationBuilder.DropTable(
                name: "Bound");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
