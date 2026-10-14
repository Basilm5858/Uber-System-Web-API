using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.Repos.Interfaces
{
    public interface IAuthRepo : IGenericRepo<User>
    {
        Task<User?> GetByEmail(string email); 
        Task<ICollection<User>> GetByName(string name);
    }
}
