using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ILevelRepository LevelRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        ISubjectLevelRepository SubjectLevelRepository { get; }
        IExamRepository ExamRepository { get; }


        Task<int> Complete();
    }
}
