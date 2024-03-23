using ReadingClubSPI_.Net.BusinessReadClBookLayer.Models.ReadingClBook;
using ReadingClubSPI_.Net.DataReadClBookLayer.Models;

namespace ReadingClubSPI_.Net.Services.Services.Contracts
{
    public interface ITokenService
    {
        IEnumerable<ReadingClBook> GetAll();

        ReadingClBook GetById(int id);

        ReadingClBook GetByIsbn(string isbn);

        ReadingClBook Create(CreateReadingClBook item);

        ReadingClBook Update(int id, UpdateReadingClBook updateReadingClBook);

        ReadingClBook Delete(int id);
    }
}
