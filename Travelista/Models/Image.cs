using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travelista.Models
{
	public class Image
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string ImageURL { get; set; }

		[ForeignKey("Trip")]
		[Required]
		public int TripId { get; set; }
		public virtual Trip? Trip { get; set; }
	}
}
