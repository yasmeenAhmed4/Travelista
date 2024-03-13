using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travelista.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscountProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Trips",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Trips");
        }
    }
}
