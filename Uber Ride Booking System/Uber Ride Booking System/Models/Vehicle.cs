using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Uber_Ride_Booking_System.Models
{
    [Index(nameof(PlateNumber), IsUnique = true)]
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Model { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string PlateNumber { get; set; } = string.Empty;
        [Required]
        public string Color { get; set; } = string.Empty;
        public User? Driver { get; set; }
        [ForeignKey(nameof(Driver))]
        public int DriverId { get; set; }

    }
}