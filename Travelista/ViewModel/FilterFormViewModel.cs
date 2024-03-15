namespace Travelista.ViewModel
{
	public class FilterFormViewModel
	{
		public double? MinPrice { get; set; }
		public double? MaxPrice { get; set; }
		public string Category { get; set; }
		public string Country { get; set; }
		public DateTime? Date { get; set; }
	}
}
