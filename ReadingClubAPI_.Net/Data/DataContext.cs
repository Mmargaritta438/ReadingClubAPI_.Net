using Microsoft.EntityFrameworkCore;
using ReadingClubAPI_.Net.Entities;

namespace ReadingClubAPI_.Net.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        
        }

        public DbSet<ReadingClub> ReadingClubs { get; set; }
    }
}
