using Application.DTOs.StudentDegree;
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
    public class StudentDegreeRepository : BaseRepository<StudentDegree>, IStudentDegreeRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentDegreeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentDegreeDTO>> GetAllStudentDegreesAsync()
        {
            var result = await _context.StudentDegrees
                .AsNoTracking()
                .Include(a => a.Subject)
                .Include(a => a.User)
                .Select(a => new StudentDegreeDTO
                (
                    a.Id,
                    a.SubjectId,
                    a.Subject!.Name,
                    a.UserId,
                    a.User!.Name,
                    a.Degree,
                    a.ExamDegree
                ))
                .ToListAsync();

            return result;
        }
    }
}
