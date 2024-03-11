using ReadingClubSPI_.Net.DataReadClBookLayer.Models;

namespace ReadingClubSPI_.Net.DataReadClBookLayer.Repositories.Contracts
{
    public class IUserBookRepository : IBaseRepository<UserBook>
    {
        bool IsUniqueLogin(string login);
        UserBook? GetUserByLogin(string login);
    }
}