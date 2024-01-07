using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Play_investe.Migrations
{
    /// <inheritdoc />
    public partial class TAXANAME : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaxName",
                table: "Bound",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxName",
                table: "Bound");
        }
    }
}
