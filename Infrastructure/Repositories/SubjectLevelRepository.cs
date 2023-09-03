using Application.DTOs.SubjectLevel;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SubjectLevelRepository : BaseRepository<SubjectLevel>, ISubjectLevelRepository
    {
        private readonly ApplicationDbContext _context;
        public SubjectLevelRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<SubjectLevelDTO>> GetAllSubjectLevelsAsync()
        {
            var result = await _context.SubjectLevels
                .AsNoTracking()
                .Include(a => a.Level)
                .Include(a => a.Subject)
                .Select(a => new SubjectLevelDTO
                {
                    Id = a.Id,
                    Level = new { a.Level!.Id, a.Level!.LevelName },
                    Subject = new {a.Subject!.Id, a.Subject!.Name }
                })
                .ToListAsync();

            return result;
        }
    }
}
