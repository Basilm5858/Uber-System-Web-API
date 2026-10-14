using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
