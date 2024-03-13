using Travelista.Models;
namespace Travelista.ViewModel
{
    public class TripViewModel
    {
       public List<Trip> trips { set; get; }
        public List<TripType> tripTypes { set; get; }
        public List<Country> Countries { set; get; }
    }
}
