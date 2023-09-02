using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        // Repositories
        public IBaseRepository<Level> LevelRepository { get; private set; }
        public IBaseRepository<Subject> SubjectRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            LevelRepository = new BaseRepository<Level>(context);
            SubjectRepository = new BaseRepository<Subject>(context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}
