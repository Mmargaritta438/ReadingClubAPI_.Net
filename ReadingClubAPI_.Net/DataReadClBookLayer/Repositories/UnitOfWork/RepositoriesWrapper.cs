using ReadingClubSPI_.Net.DataReadClBookLayer.Data;
using ReadingClubSPI_.Net.DataReadClBookLayer.Repositories.Contracts;
using ReadingClubSPI_.Net.DataReadClBookLayer.Repositories.Implementations;

namespace ReadingClubSPI_.Net.DataReadClBookLayer.Repositories.UnitOfWork
{
    public class RepositoriesWrapper : IRepositoriesWrapper
    {
        private readonly LibraryDbContext _dbContext;
        private IReadClBookRepository _readingClBookRepository;
        private IUserBookRepository _userBookRepository;
        private bool _isDisposed;

        public RepositoriesWrapper(LibraryDbContext dbContext) { _dbContext = dbContext; }

        public IReadClBookRepository ReadClBooks
            => _readingClBookRepository ??= new ReadClBookRepository(_dbContext);

        public IUserBookRepository UserBooks
            => _userBookRepository ??= new UserBookRepository(_dbContext);

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                _isDisposed = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}