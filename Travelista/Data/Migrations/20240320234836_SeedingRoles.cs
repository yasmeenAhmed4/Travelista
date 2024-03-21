using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using Travelista.Areas.Identity.Data;


#nullable disable

namespace Travelista.Data.Migrations
{
	/// <inheritdoc />
	public partial class SeedingRoles : Migration
	{

		protected override void Up(MigrationBuilder migrationBuilder)
		{

			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
				values: new object[] { Guid.NewGuid().ToString(), Role.User, Role.User.ToUpper(), Guid.NewGuid().ToString() }
				);

			var adminRoleId = Guid.NewGuid().ToString();

			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
				values: new object[] { adminRoleId, Role.Admin, Role.Admin.ToUpper(), Guid.NewGuid().ToString() }
				);

			var adminUserId = Guid.NewGuid().ToString();
			var passwordHasher = new PasswordHasher<ApplicationUser>();
			var hashedPassword = passwordHasher.HashPassword(null, "Abc123!");

			migrationBuilder.InsertData(
					table: "AspNetUsers",
					columns: new[] { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount", "FirstName", "LastName", "Address" },
					values: new object[] { adminUserId, "Travelistaco", "TRAVELISTACO", "Travelistaco@outlook.com", "TRAVELISTACO@OUTLOOK.COM", true, hashedPassword, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), false, false, true, 0, "Mohamed", "Raafat", "Address" }
				);

			migrationBuilder.InsertData(
			   table: "AspNetUserRoles",
			   columns: new[] { "UserId", "RoleId" },
			   values: new object[] { adminUserId, adminRoleId }
		   );
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DELETE FROM [AspNetRoles]");
			migrationBuilder.Sql("DELETE FROM [AspNetUserRoles]");
			migrationBuilder.Sql("DELETE FROM [AspNetUsers]");

		}
	}
}
