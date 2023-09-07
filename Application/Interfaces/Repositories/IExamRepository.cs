using Application.DTOs.Exam;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IExamRepository: IBaseRepository<Exam>
    {
        Task<IEnumerable<ExamDTO>> GetAllExamsAsync();
        Task<ExamDTO> GetExamByIdAsync(int id);
    }
}
