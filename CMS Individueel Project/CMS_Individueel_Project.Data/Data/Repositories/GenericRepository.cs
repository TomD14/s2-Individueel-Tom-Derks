using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Individueel_Project.Data.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        protected DbContext _context;
        protected DbSet<TEntity> table;

        public GenericRepository(DbContext context)
        {
            _context = context;
            table = _context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return table.ToList();
        }

        public virtual IEnumerable<TEntity> GetAll(string[] includes)
        {
            var entities = table.AsQueryable();
            foreach (string include in includes)
            {
                entities = entities.Include(include);
            }
            return entities.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(string[] includes)
        {
            var entities = table.AsQueryable();
            foreach (string include in includes)
            {
                entities = entities.Include(include);
            }
            return await entities.ToListAsync();
        }

        public virtual TEntity GetById(object id)
        {
            return table.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await table.FindAsync(id);
        }

        public virtual void Add(TEntity entity)
        {
            table.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            table.Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            table.Remove(entity);
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}