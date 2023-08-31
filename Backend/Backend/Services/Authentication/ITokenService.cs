using Backend.Models;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services.Authentication
{
    public interface ITokenService
    {
        public string CreateToken(User user, IList<string> roles);
    }
}
