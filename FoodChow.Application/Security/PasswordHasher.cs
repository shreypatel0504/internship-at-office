using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int WorkFactor = 11;

        public string Hash(string plainPassword) =>
            BCrypt.Net.BCrypt.HashPassword(plainPassword, workFactor: WorkFactor);

        public bool Verify(string plainPassword, string hashedPassword) =>
            BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
    }
}