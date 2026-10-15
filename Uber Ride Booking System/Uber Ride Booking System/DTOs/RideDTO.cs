using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.DTOs
{
    public class RideDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string DropOffLocation { get; set; } = string.Empty;
        [Required]
        [MaxLength(150)]
        public string PickupLocation { get; set; } = string.Empty;
        [Range(20, 5000)]
        public int Fare { get; set; }
        [Required]
        public string Status { get; set; } = "Pending";
        public int RiderId { get; set; }
        public int? DriverId { get; set; }
    }

    public class Report
    {
        [Range(20, 5000)]
        public int MinFare { get; set; }
        public int maxFare { get; set; }
        [Required]
        public ICollection<string> Status { get; set; } = new List<string>();
    }

    public class CreateRideDTO
    {
        [Required]
        [MaxLength(150)]
        public string DropOffLocation { get; set; } = string.Empty;
        [Required]
        [MaxLength(150)]
        public string PickupLocation { get; set; } = string.Empty;
        [Range(20, 5000)]
        public int Fare { get; set; }
        [Required]
        public string Status { get; set; } = "Pending";
        public int RiderId { get; set; }
        public int? DriverId { get; set; }
    }

}
