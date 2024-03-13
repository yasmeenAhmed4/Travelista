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

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

		public DbSet<Trip> Trips { get; set; }
		public DbSet<TripType> TripTypes { get; set; }
		public DbSet<Wishlist> Wishlists { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Contact> Messages { get; set; }
	}
}
