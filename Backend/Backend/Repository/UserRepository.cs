using Backend.Models.Customer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EverythingAppContext _dbContext;

        public UserRepository(EverythingAppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<IdentityUser> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public IdentityUser? GetByName(string userName)
        {
            return _dbContext.Users.FirstOrDefault(c => c.UserName == userName);
        }
        public void Delete(IdentityUser user)
        {
            _dbContext.Remove(user);
            _dbContext.SaveChanges();
        }

        public void Update(IdentityUser user)
        {
            _dbContext.Update(user);
            _dbContext.SaveChanges();
        }
    }
}
