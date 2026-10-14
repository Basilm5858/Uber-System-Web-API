using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.DTOs
{
    public class CreateVehicleDTO
    {
        [Required]
        [MaxLength(50)]
        public string Model { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string PlateNumber { get; set; } = string.Empty;
        [Required]
        public string Color { get; set; } = string.Empty;
        public int DriverId { get; set; }
    }
}
