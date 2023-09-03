using Application.DTOs.Subject;
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
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        private readonly ApplicationDbContext _context;
        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubjectDTO>> GetAllSubjectsAsync()
        {
            var subjects = await _context.Subjects
                .AsNoTracking()
                .Include(a => a.Teacher)
                .Select(a => new SubjectDTO
                {
                    Id = a.Id,
                    SubjectName = a.Name,
                    Teacher = new
                    {
                        a.Teacher!.Id,
                        a.Teacher.Email
                    }
                })
                .ToListAsync();

            return subjects;
        }

        public async Task<SubjectDTO> GetSubjectByIdAsync(int id)
        {
            var subject = await _context.Subjects
                .AsNoTracking()
                .Include(a => a.Teacher)
                .Select(a => new SubjectDTO
                {
                    Id = a.Id,
                    SubjectName = a.Name,
                    Teacher = new
                    {
                        a.Teacher!.Id,
                        a.Teacher.Email
                    }
                })
                .FirstOrDefaultAsync(a => a.Id == id);

            return subject;
        }
    }
}
