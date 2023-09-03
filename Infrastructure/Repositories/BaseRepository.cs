using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        private IQueryable<T> GetDataWithIncludes(string[] includes)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            if (includes is not null)
                foreach (var item in includes)
                    query = query.Include(item);

            return query;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string[]? includes = null)
        {
            return await GetDataWithIncludes(includes).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhereAsync(
            Expression<Func<T, bool>> match,
            Expression<Func<T, object>>? orderBy,
            string[]? includes = null,
            string orderByDirection = OrderBy.Ascending)
        { 
            IQueryable<T> query = GetDataWithIncludes(includes).Where(match);

            if (orderBy is not null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> match, string[]? includes = null)
        {
            var result = await GetDataWithIncludes(includes).FirstOrDefaultAsync(match);
            return result;
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        {
            return await _context.Set<T>().AsQueryable().CountAsync(criteria);
        }
        
        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().AsQueryable().CountAsync();
        }
        
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
        
        public Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }
    }
}
