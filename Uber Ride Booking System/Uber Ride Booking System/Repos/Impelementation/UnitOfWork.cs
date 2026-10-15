using Uber_Ride_Booking_System.Data;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Repos.Impelementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly My_AppContext _context;

        public UnitOfWork(My_AppContext context, IAuthRepo authRepo, IVehicle vehicle, IPayment payment, IRating rating, IRideRepo rideRepo)
        {
            _context = context;
            this.authRepo = authRepo;
            this.vehicle = vehicle;
            this.payment = payment;
            this.rating = rating;
            this.rideRepo = rideRepo;
        }

        public IAuthRepo authRepo { get; }

        public IVehicle vehicle { get; }

        public IPayment payment { get; }

        public IRating rating { get; }

        public IRideRepo rideRepo { get; }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
