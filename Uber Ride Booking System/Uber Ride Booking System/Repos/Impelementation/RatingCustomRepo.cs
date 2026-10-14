using Uber_Ride_Booking_System.Data;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Repos.Impelementation
{
    public class RatingCustomRepo : GenericRepo<Rating>, IRating
    {
        public RatingCustomRepo(My_AppContext context) : base(context)
        {
        }
    }
}
