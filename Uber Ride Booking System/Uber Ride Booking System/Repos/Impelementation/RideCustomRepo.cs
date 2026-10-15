using Microsoft.EntityFrameworkCore;
using Uber_Ride_Booking_System.Data;
using Uber_Ride_Booking_System.DTOs;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Repos.Impelementation
{
    public class RideCustomRepo : GenericRepo<Ride>, IRideRepo
    {
        private readonly My_AppContext _context;

        public RideCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Report> Filter()
        {
            return new Report
            {
                MinFare = await _context.Rides.MinAsync(x => x.Fare),
                maxFare = await _context.Rides.MaxAsync(x => x.Fare),
                Status = await _context.Rides.Select(x => x.Status).ToListAsync()
            };
        }

        public async Task<ICollection<RideDTO>> GetAllByPages(int pageno, int pagesize)
        {
            return await _context.Rides
                .OrderBy(x => x.Id)
                .Skip((pageno - 1) * pagesize)
                .Take(pagesize)
                .Select(x => new RideDTO
                {
                    DriverId = x.DriverId,
                    Status = x.Status,
                    DropOffLocation = x.DropOffLocation,
                    Fare = x.Fare,
                    Id = x.Id,
                    PickupLocation = x.PickupLocation,
                    RiderId = x.RiderId
                }).ToListAsync();

        }

        public async Task<ICollection<RideDTO>> SearchByPickup(string pickup)
        {
            return await _context.Rides
                .Where(x => x.PickupLocation.Contains(pickup))
                .Select(x => new RideDTO
                {
                    DriverId = x.DriverId,
                    Status = x.Status,
                    DropOffLocation = x.DropOffLocation,
                    Fare = x.Fare,
                    Id = x.Id,
                    PickupLocation = x.PickupLocation,
                    RiderId = x.RiderId
                }).ToListAsync();
        }
    }
}
