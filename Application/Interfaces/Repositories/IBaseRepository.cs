using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetFirstAsync(Expression<Func<T, bool>> match);
        Task<IEnumerable<T>> GetWhereAsync(
            Expression<Func<T, bool>> match, 
            Expression<Func<T, object>>? orderBy, 
            string orderByDirection = "ASC"
        );
        Task<T> AddAsync(T entity);
        Task Update(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> criteria);
    }
}
