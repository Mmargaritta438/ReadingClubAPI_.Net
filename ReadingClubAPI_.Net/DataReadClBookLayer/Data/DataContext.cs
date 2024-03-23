using Microsoft.EntityFrameworkCore;
using ReadingClubAPI_.Net.Entities;

namespace ReadingClubSPI_.Net.DataReadClBookLayer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ReadingClub> ReadingClubs { get; set; }
    }
}
