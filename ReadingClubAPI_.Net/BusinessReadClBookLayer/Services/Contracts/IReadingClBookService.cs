using ReadingClubSPI_.Net.BusinessReadClBookLayer.Models.ReadingClBook;

namespace ReadingClubSPI_.Net.BusinessReadClBookLayer.Services.Contracts
{
    public interface IReadingClBookService
    {
        IEnumerable<ReadingClBook> GetAll();

        ReadingClBook GetById(int id);

        ReadingClBook GetByIsbn(string isbn);

        ReadingClBook Create(CreateReadingClBook item);

        ReadingClBook Update(int id, UpdateReadingClBook updateReadingClBook);

        ReadingClBook Delete(int id);
    }
}