using System.ComponentModel.DataAnnotations;

namespace Travelista.Models
{
	public class Country
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		public virtual List<Trip> Trips { get; set; } = new List<Trip>();
	}
}
