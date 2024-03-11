using ReadingClubSPI_.Net.DataReadClBookLayer.Data;
using ReadingClubSPI_.Net.DataReadClBookLayer.Models;
using ReadingClubSPI_.Net.DataReadClBookLayer.Repositories.Contracts;

namespace ReadingClubSPI_.Net.DataReadClBookLayer.Repositories.Implementations
{
    public class ReadingClBookRepository : BaseRepository<ReadingClBook>, IReadingClBookRepository
    {
        public ReadingClBookRepository(LibraryDbContext context) : base(context) { }

        public virtual ReadingClBook? GetByIsbn(string isbn)
            => _dbSet.FirstOrDefault(x => x.Isbn == isbn);

        public bool IsUniqueIsbn(string isbn)
        {
            var result = _dbSet.Any(x => x.Isbn == isbn);
            return !result;
        }
    }
}