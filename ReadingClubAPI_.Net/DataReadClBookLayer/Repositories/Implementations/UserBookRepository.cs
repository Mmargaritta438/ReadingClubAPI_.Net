using ReadingClubSPI_.Net.DataReadClBookLayer.Data;
using ReadingClubSPI_.Net.DataReadClBookLayer.Models;
using ReadingClubSPI_.Net.DataReadClBookLayer.Repositories.Contracts;

namespace ReadingClubSPI_.Net.DataReadClBookLayer.Repositories.Implementations
{
    public class UserBookRepository : BaseRepository<UserBook>, IUserBookRepository
    {
        public UserBookRepository(LibraryDbContext context) : base(context) { }

        public bool IsUniqueLogin(string login)
        {
            var result = _dbSet.Any(x => x.Login == login);
            return !result;
        }

        public UserBook? GetUserByLogin(string login)
            => _dbSet.FirstOrDefault(x => x.Login == login);
    }
}