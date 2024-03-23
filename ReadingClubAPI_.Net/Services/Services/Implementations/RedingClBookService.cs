using ReadingClubSPI_.Net.BusinessReadClBookLayer.Exceptions;
using ReadingClubSPI_.Net.BusinessReadClBookLayer.Models.ReadingClBook;
using ReadingClubSPI_.Net.DataReadClBookLayer.Models;
using ReadingClubSPI_.Net.DataReadClBookLayer.Repositories.UnitOfWork;
using ReadingClubSPI_.Net.Services.Services.Contracts;

namespace ReadingClubSPI_.Net.Services.Services.Implementations
{
    public class RedingClBookService : IReadingClBookService
    {
        private readonly IRepositoriesWrapper _repositoriesWrapper;

        private readonly IMapper _mapper;

        public RedingClBookService(IRepositoriesWrapper repositoriesWrapper, IMapper mapper)
        {
            _repositoriesWrapper = repositoriesWrapper;
            _mapper = mapper;
        }


        public ReadingClBook GetById(int id)
        {
            var book = _repositoriesWrapper.Books.Get(id);
            if (book == null)
            {
                throw new DbEntityNotFoundException($"Book with id {id} not found int the database.");
            }

            return book;
        }
        public IEnumerable<ReadingClBook> GetAll()
            => _repositoriesWrapper.Books.GetAll();

        public ReadingClBook GetByIsbn(string isbn)
        {
            var book = _repositoriesWrapper.Books.GetByIsbn(isbn);
            if (book == null)
            {
                throw new DbEntityNotFoundException($"Book with ISBN {isbn} not found int the database.");
            }

            return book;
        }

        public ReadingClBook Create(CreateReadingClBook createRedingClBookDto)
        {
            var isUniqueIsbn = _repositoriesWrapper.Books.IsUniqueIsbn(createRedingClBookDto.Isbn);

            if (!isUniqueIsbn)
            {
                throw new ItemAlreadyExistsException($"ISBN: '{createRedingClBookDto.Isbn}' already exists in database!");
            }

            var book = _mapper.Map<ReadingClBook>(createRedingClBookDto);
            _repositoriesWrapper.Books.Save(book);
            return book;
        }

        public ReadingClBook Update(int id, UpdateReadingClBook updateRedingClBook)
        {
            var bookToUpdate = _repositoriesWrapper.Books.Get(id);

            if (bookToUpdate == null)
            {
                throw new DbEntityNotFoundException($"Book with id {id} not found in the database.");
            }

            _mapper.Map(updateRedingClBook, bookToUpdate);
            _repositoriesWrapper.Books.Update(bookToUpdate);

            return bookToUpdate;
        }


        public ReadingClBook Delete(int id)
        {
            var book = GetById(id);

            if (book == null)
            {
                throw new DbEntityNotFoundException($"Book with id {id} not found in the database.");
            }

            return _repositoriesWrapper.Books.Remove(book);
        }
    }
}