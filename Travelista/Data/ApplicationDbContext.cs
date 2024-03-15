using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
