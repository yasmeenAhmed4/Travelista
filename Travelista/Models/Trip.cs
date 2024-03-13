using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Travelista.Models
{
	public class Trip
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public string Program { get; set; }

		[Required]
		[Range(0, double.MaxValue)]
		[DataType(DataType.Currency)]
		public double Cost { get; set; }

		[Required]
		public int Duration { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Capacity { get; set; }

		public bool IsTrend { get; set; }

		[Range(0, 100)]
		[DefaultValue(0.00)]
		public double Discount { get; set; }
		public DateTime StartDate { get; set; }

		public virtual List<Image> Images { get; set; } = new List<Image>();

		[Required]
		[ForeignKey("Country")]
		public int CountryId { get; set; }

		public virtual Country? Country { get; set; }

		[Required]
		[ForeignKey("TripType")]
		public int TripTypeID { get; set; }

		public virtual TripType? TripType { get; set; }

		public virtual List<TripReView> TripReviews { get; set; } = new List<TripReView>();

		public bool IsAvailable()
		{
			if (Capacity > 0) return true;
			else return false;
		}

		public DateTime ReturnDate()
		{
			return StartDate.AddDays(Duration);
		}
		public double CostAfterDiscount()
		{
			return Cost * (1 - Discount / 100);
		}
	}
}
