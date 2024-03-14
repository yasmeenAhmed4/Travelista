using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travelista.Models
{
	public class TripReView
	{
		public int Id { get; set; }

		[ForeignKey("Trip")]
		public int TripId { get; set; }

		[Required]
		public string? Message { get; set; }

		[Required]
		public string? Username { get; set; }

		[Required]
		public string? Email { get; set; }

		public Trip? Trip { get; set; }
	}
}
