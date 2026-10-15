using Uber_Ride_Booking_System.DTOs;
using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.Repos.Interfaces
{
    public interface IRideRepo : IGenericRepo<Ride>
    {
        Task<ICollection<RideDTO>> GetAllByPages(int pageno, int pagesize);
        Task<ICollection<RideDTO>> SearchByPickup(string pickup);
        Task<Report> Filter();

    }
}
