using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
        Task<List<T>> GetAllAsync(string? includeProperties = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }

}
