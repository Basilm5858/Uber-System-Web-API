using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Uber_Ride_Booking_System.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;
        public Vehicle? Vehicle { get; set; }
        public ICollection<Ride> RiderRides { get; set; } = new List<Ride>();
        public ICollection<Ride> DriverRides { get; set; } = new List<Ride>();

    }
}