using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharingExpenses.Migrations
{
    public partial class addtotalCostonGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "Groups",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Expenses");
        }
    }
}
