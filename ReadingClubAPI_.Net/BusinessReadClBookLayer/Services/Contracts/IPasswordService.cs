namespace ReadingClubSPI_.Net.BusinessReadClBookLayer.Services.Contracts
{
    public interface IPasswordService
    {
        string HashPassword(string password);

        bool IsPasswordCorrect(string password, string hashedPassword);
    }
}