using Uber_Ride_Booking_System.Data;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Repos.Impelementation
{
    public class RideCustomRepo : GenericRepo<Ride>, IRideRepo
    {
        public RideCustomRepo(My_AppContext context) : base(context)
        {
        }
    }
}
