using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travelista.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTrendProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTrend",
                table: "Trips",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTrend",
                table: "Trips");
        }
    }
}
