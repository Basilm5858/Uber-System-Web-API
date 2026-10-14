using Uber_Ride_Booking_System.Data;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Repos.Impelementation
{
    public class PaymentCustomRepo : GenericRepo<Payment>, IPayment
    {
        public PaymentCustomRepo(My_AppContext context) : base(context)
        {
        }
    }
}
