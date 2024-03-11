using ReadingClubSPI_.Net.DataReadClBookLayer.Models;

namespace ReadingClubSPI_.Net.DataReadClBookLayer.Repositories.Contracts
{
    public class IReadingClBookRepository : IReadingClBaseRepository<ReadingClBook>
    {
        ReadingClBook? GetByIsbn(string isbn);

        bool IsUniqueIsbn(string isbn);
    }
}