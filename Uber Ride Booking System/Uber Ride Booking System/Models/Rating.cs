using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uber_Ride_Booking_System.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string? Comment { get; set; }
        public Ride Ride { get; set; }
        [ForeignKey(nameof(Ride))]
        public int RideId { get; set; }
    }
}