using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase.Interface
{
    public interface IBaseRepositorio<TEntity> where TEntity : class
    {
        void Remove(int id);
        void Update(TEntity item);
        void Add(TEntity item);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void SetModifiedState(TEntity entity);
    }
}
