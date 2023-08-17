using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Models.Customer
{
    public class Admin
    {
        public int admin_id { get; init; }
        public string? Username { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Email { get; init; }
        public string? PasswordHash { get; set; }
        public string? Salt { get; set; }

        // Method to set the password hash and salt
        public void SetPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                Salt = GenerateSalt();
                byte[] saltedPassword = Encoding.UTF8.GetBytes(password + Salt);
                byte[] hash = sha256.ComputeHash(saltedPassword);
                PasswordHash = Convert.ToBase64String(hash);
            }
        }

        // Method to validate a password
        public bool ValidatePassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] saltedPassword = Encoding.UTF8.GetBytes(password + Salt);
                byte[] hash = sha256.ComputeHash(saltedPassword);
                return PasswordHash == Convert.ToBase64String(hash);
            }
        }

        private static string GenerateSalt()
        {
            byte[] randomBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }
    }
}