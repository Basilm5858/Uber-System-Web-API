using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uber_Ride_Booking_System.Models
{
    public class Ride
    {
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
        public User Rider { get; set; }
        public User? Driver { get; set; }
        [ForeignKey(nameof(Rider))]
        public int RiderId { get; set; }
        [ForeignKey(nameof(Driver))]
        public int? DriverId { get; set; }
        public Payment? Payment { get; set; }
        public Rating? Rating { get; set; }
    }
}