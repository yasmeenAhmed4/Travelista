using System.ComponentModel.DataAnnotations;

namespace Travelista.Models
{
	public class Contact
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required, EmailAddress]
		public string Email { get; set; }
		[Required]
		public string Subject { get; set; }

		[Required]
		public string MessageContent { get; set; }
	}
}
