namespace Uber_Ride_Booking_System.Repos.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthRepo authRepo { get; }
        IVehicle vehicle { get; }
        IPayment payment { get; }
        IRating rating { get; }
        IRideRepo ratingRepo { get; }
        Task SaveChanges();
    }
}
