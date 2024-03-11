using Microsoft.EntityFrameworkCore;
using ReadingClubSPI_.Net.DataReadClBookLayer.Data;
using ReadingClubSPI_.Net.DataReadClBookLayer.Models;
using ReadingClubSPI_.Net.DataReadClBookLayer.Repositories.Contracts;

namespace ReadingClubSPI_.Net.DataReadClBookLayer.Repositories.Implementations
{
    public abstract class BaseRepository<DbModel> : IBaseRepository<DbModel> where DbModel : BaseModel
    {
        protected LibraryDbContext _context;
        protected DbSet<DbModel> _dbSet;

        protected BaseRepository(LibraryDbContext context)
        {
            _context = context;
            _dbSet = context.Set<DbModel>();
        }

        public virtual DbModel? Get(int id)
            => _dbSet.FirstOrDefault(x => x.Id == id);

        public virtual IEnumerable<DbModel> GetAll()
            => _dbSet.ToList();

        public virtual DbModel Save(DbModel model)
        {
            _dbSet.Add(model);
            _context.SaveChanges();
            return model;
        }

        public virtual DbModel Update(DbModel model)
        {
            _context.Update(model);
            _context.SaveChanges();
            return model;
        }

        public virtual DbModel Remove(DbModel model)
        {
            var deletedModel = _dbSet.Remove(model).Entity;
            _context.SaveChanges();
            return deletedModel;
        }
    }
}