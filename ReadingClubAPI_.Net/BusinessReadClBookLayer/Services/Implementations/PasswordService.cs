using ReadingClubSPI_.Net.BusinessReadClBookLayer.Services.Contracts;

namespace ReadingClubSPI_.Net.BusinessReadClBookLayer.Services.Implementations
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GenerateSalt());
        }

        public bool IsPasswordCorrect(string password, string hashedPassword)
        {
            return Verify(password, hashedPassword);
        }
    }
}