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
    public class ExamRepository : BaseRepository<Exam>, IExamRepository
    {
        private readonly ApplicationDbContext _context;
        public ExamRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
