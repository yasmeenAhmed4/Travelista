using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travelista.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StripePaymentIntentId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "effe1586-9b0e-4a5a-a385-8bc2f1bd8b3a", "AQAAAAIAAYagAAAAEAKLngtg2W6GXlx7v0571iLZf3wXN14SfjPjBWLFcQraETqjxgl/yT0iwvDAHa51Zg==", "d25fbbc3-9201-4a6d-bff5-033702584e53" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "StripePaymentIntentId",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb04c4db-9dbf-4e0d-b834-b3916a3ecd04", "AQAAAAIAAYagAAAAECM1GKWwRp1U1GUD1kfy1cv+v0J8SCYroTKRl0XKT1zSmw3pRsxE84+s6aJIHnjt9A==", "5678e6b9-5719-412f-9ef0-49196c31a6bb" });
        }
    }
}
