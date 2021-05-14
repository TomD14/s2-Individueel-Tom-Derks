using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS_Individueel_Project.Data.Data.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(string[] includes);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(string[] includes);
        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

        Task<int> SaveAsync();
    }
}