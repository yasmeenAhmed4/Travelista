using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Travelista.Areas.Identity.Data;

namespace Travelista.Models
{
	public class Wishlist
	{
		[Key]
		public int Id { get; set; }

		[DataType(DataType.Currency)]
		public double Cost { get; set; }

		[ForeignKey("Trip")]
		[Required]
		public int TripId { get; set; }
		public virtual Trip? Trip { get; set; }

		[ForeignKey("ApplicationUser")]
		[Required]
		public string UserId { get; set; }
		public virtual ApplicationUser? ApplicationUser { get; set; }
	}
}
