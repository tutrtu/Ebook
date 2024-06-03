using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using EbookAPI.DataAccess.Entites;
using EbookAPI.DataAccess.Interfaces;
using EbookAPI.DataAccess.Entites;
using EbookAPI.Models;

namespace EbookAPI.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly eBookStoreContext _context;

        public UserRepository(eBookStoreContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Users.Include(u => u.Role)
                .SingleOrDefaultAsync(u => u.EmailAddress == email && u.Password == password);
        }
        public async Task<User> AddUserAsync(string email, string password)
        {
            var user = new User
            {
                EmailAddress = email,
                Password = password
                // You might want to set other properties of the user object here
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
