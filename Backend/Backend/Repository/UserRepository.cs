using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Backend.Models;

namespace Backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EverythingAppContext _dbContext;
        public UserRepository(EverythingAppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(c => c.Email == email);
        }
        public void Delete(User user)
        {
            _dbContext.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
