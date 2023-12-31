﻿using Domain.Entities;
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
        Task<IEnumerable<T>> GetAllAsync(string[]? includes = null);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> match, string[]? includes = null);
        Task<IEnumerable<T>> GetWhereAsync(
            Expression<Func<T, bool>> match, 
            Expression<Func<T, object>>? orderBy, 
            string[]? includes = null,
            string orderByDirection = OrderBy.Ascending
        );
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> criteria);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        Task Delete(T entity);
    }
}
