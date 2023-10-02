using Application.DTOs.StudentDegree;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IStudentDegreeRepository: IBaseRepository<StudentDegree>
    {
        Task<IEnumerable<StudentDegreeDTO>> GetAllStudentDegreesAsync();
    }
}
