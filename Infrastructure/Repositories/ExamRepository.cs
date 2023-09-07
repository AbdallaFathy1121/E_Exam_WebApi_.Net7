using Application.DTOs.Exam;
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
    public class ExamRepository : BaseRepository<Exam>, IExamRepository
    {
        private readonly ApplicationDbContext _context;
        public ExamRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<ExamDTO>> GetAllExamsAsync()
        {
            var result = await _context.Exams
                .AsNoTracking()
                .Include(a => a.User)
                .Include(a => a.SubjectLevel)
                .Select(a => new ExamDTO
                {
                    Id = a.Id,
                    StartDateTime = a.StartDateTime,
                    EndDateTime = a.EndDateTime,
                    ExamName = a.ExamName,
                    Teacher = new { a.User!.Id, a.User!.Email },
                    Subject = new { a.SubjectLevel!.Subject!.Id, a.SubjectLevel!.Subject!.Name },
                    Level = new { a.SubjectLevel!.Level!.Id, a.SubjectLevel.Level.LevelName }
                })
                .ToListAsync();

            return result;
        }

        public async Task<ExamDTO> GetExamByIdAsync(int id)
        {
            var result = await _context.Exams
                .AsNoTracking()
                .Include(a => a.User)
                .Include(a => a.SubjectLevel)
                .Select(a => new ExamDTO
                {
                    Id = a.Id,
                    StartDateTime = a.StartDateTime,
                    EndDateTime = a.EndDateTime,
                    ExamName = a.ExamName,
                    Teacher = new { a.User!.Id, a.User!.Email },
                    Subject = new { a.SubjectLevel!.Subject!.Id, a.SubjectLevel!.Subject!.Name },
                    Level = new { a.SubjectLevel!.Level!.Id, a.SubjectLevel.Level.LevelName }
                })
                .FirstOrDefaultAsync(a => a.Id == id);

            return result;
        }
    }
}
