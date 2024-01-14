using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Play_investe.Migrations
{

    /// <inheritdoc />
    public partial class boundchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaxName",
                table: "Bound",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Index",
                table: "Bound",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "FLOAT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaxName",
                table: "Bound",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Index",
                table: "Bound",
                type: "FLOAT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");
        }
    }
}
