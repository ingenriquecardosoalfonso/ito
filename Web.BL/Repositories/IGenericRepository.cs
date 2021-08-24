using System.Collections.Generic;
using System.Threading.Tasks;
using Web.BL.Models;
using Web.BL.Services.Implements;

namespace Web.BL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(int id);
        Task<IEnumerable<Menu>> GetMenusHijosByIdAsync(int id);

        Task<IEnumerable<LMenu>> GetMenusAsync();
    }
}
