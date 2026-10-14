using System;
using System.ComponentModel.DataAnnotations;

namespace Uber_Ride_Booking_System.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PaymentMethod { get; set; } = string.Empty;
        [Required]
        public string Status { get; set; } = string.Empty;
        [Required]
        public DateTime PaymentDate {  get; set; }
        [Range(12, 5000)]
        public int Amount { get; set; }
        public Ride Ride { get; set; }
        public int RideId { get; set; }
    }
}