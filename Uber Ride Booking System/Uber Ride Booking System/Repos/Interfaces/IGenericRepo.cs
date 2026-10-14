namespace Uber_Ride_Booking_System.Repos.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<ICollection<T>> GetAll();
        Task<T?> GetById(int id);
        Task Add(T entity);
        void Delete(T entity);
    }
}
