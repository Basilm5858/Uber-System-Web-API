using Uber_Ride_Booking_System.Data;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Repos.Impelementation
{
    public class VehicleCustomRepo : GenericRepo<Vehicle>, IVehicle
    {
        public VehicleCustomRepo(My_AppContext context) : base(context)
        {
        }
    }
}
