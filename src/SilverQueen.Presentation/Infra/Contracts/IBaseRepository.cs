using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverQueen.Presentation.Infra.Contracts
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task CreateAsync(TEntity obj);
        Task UpdateAsync(TEntity obj);
        Task DeleteAsync(Guid id);

        Task<List<TEntity>> GetAllAsync(); 
        Task<TEntity> GetByIdAsync(Guid id); 
    }
}
