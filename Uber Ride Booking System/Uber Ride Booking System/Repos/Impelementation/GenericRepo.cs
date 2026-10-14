using Microsoft.EntityFrameworkCore;
using Uber_Ride_Booking_System.Data;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Repos.Impelementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly My_AppContext _context;
        public GenericRepo(My_AppContext context)
        {
            _context = context;
        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);

        }
    }
}
