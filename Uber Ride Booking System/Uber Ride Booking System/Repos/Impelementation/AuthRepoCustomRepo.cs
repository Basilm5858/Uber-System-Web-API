using Microsoft.EntityFrameworkCore;
using Uber_Ride_Booking_System.Data;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Repos.Impelementation
{
    public class AuthRepoCustomRepo : GenericRepo<User>, IAuthRepo
    {
        private readonly My_AppContext _context;
        public AuthRepoCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<ICollection<User>> GetByName(string name)
        {
            return await _context.Users
                .Where(x => x.FullName.Contains(name))
                .ToListAsync();
        }
    }
}
