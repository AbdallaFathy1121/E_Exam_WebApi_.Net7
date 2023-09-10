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
        public ILevelRepository LevelRepository { get; private set; }
        public ISubjectRepository SubjectRepository { get; private set; }
        public ISubjectLevelRepository SubjectLevelRepository { get; private set; }
        public IExamRepository ExamRepository { get; private set; }
        public IQuestionRepository QuestionRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            LevelRepository = new LevelRepository(context);
            SubjectRepository = new SubjectRepository(context);
            SubjectLevelRepository = new SubjectLevelRepository(context);
            ExamRepository = new ExamRepository(context);
            QuestionRepository = new QuestionRepository(context);
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
