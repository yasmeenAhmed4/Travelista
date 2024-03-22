using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Travelista.Areas.Identity.Data;
using Travelista.Models;

namespace Travelista.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public ApplicationDbContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.Build();
			optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.FirstName).HasDefaultValue("DefaultFirstName");
                entity.Property(e => e.LastName).HasDefaultValue("DefaultLastName");
            });

            builder.Entity<IdentityRole>().HasData(
              new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
              new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
            );

            // Seed initial users
            ApplicationUser adminUser = new ApplicationUser
            {
                Id = "1",
                FirstName = "Mohamed",
                LastName = "Raafat",
                UserName = "Travelistaco",
                NormalizedUserName = "TRAVELISTACO",
                Email = "Travelistaco@outlook.com",
                NormalizedEmail = "TRAVELISTACO@OUTLOOK.COM",
                EmailConfirmed = true
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Abc123!"); // Replace with actual password

            builder.Entity<ApplicationUser>().HasData(adminUser);


            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = "1" } // Admin user assigned Admin role
            );











            base.OnModelCreating(builder);
        }

		public DbSet<Trip> Trips { get; set; }
		public DbSet<TripType> TripTypes { get; set; }
		public DbSet<WishlistItem> WishlistItems { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Contact> Messages { get; set; }
		public DbSet<TripReView> TripReview { get; set; }

	}
}
