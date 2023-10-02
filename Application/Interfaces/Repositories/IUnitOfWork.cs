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
        ISubjectRepository SubjectRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IStudentDegreeRepository StudentDegreeRepository { get; }


        Task<int> Complete();
    }
}
