using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Travelista.Areas.Identity.Data;

namespace Travelista.Models
{
	public class Booking
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey("Trip")]
		public int TripID { get; set; }
		public virtual Trip? Trip { get; set; }

		[DataType(DataType.Currency)]
		public double Cost { get; set; }
		public DateTime BookDate { get; set; }

		[Required]
		[ForeignKey("ApplicationUser")]
		public string UserId { get; set; }
		public virtual ApplicationUser? ApplicationUser { get; set; }
	}
}
