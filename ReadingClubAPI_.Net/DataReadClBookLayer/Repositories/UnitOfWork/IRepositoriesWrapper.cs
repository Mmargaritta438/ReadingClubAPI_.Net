using ReadingClubSPI_.Net.DataReadClBookLayer.Repositories.Contracts;

namespace ReadingClubSPI_.Net.DataReadClBookLayer.Repositories.UnitOfWork
{
    public class IRepositoriesWrapper : IDisposable
    {
        IReadingClBookRepository ReadingClBooks { get; }

        IUserBookRepository UserBooks { get; }
    }
}