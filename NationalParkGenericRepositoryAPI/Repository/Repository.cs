using Microsoft.EntityFrameworkCore;
using NationalParkGenericRepositoryAPI.Data;
using NationalParkGenericRepositoryAPI.Repository.IRepository;

namespace NationalParkGenericRepositoryAPI.Repository
{
    public class Repository<T> :IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public ICollection<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public bool Exists(int id)
        {
            return _dbSet.Find(id) != null;
        }

        public bool Create(T entity)
        {
            _dbSet.Add(entity);
            return Save();
        }

        public bool Update(T entity)
        {
            _dbSet.Update(entity);
            return Save();
        }

        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }
    }
}
