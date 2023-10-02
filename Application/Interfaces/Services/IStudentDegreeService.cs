using Application.DTOs;
using Application.DTOs.StudentDegree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IStudentDegreeService
    {
        Task<MainResponse> GetAllStudentDegreesAsync();
        Task<MainResponse> GetStudentDegreesBySubjectIdAsync(int subjectId);
        Task<MainResponse> GetStudentDegreesByUserIdAsync(string userId);
        Task<MainResponse> GetStudentDegreeByUserIdAndSubjectIDAsync(string userId, int subjectId);
        Task<MainResponse> AddStudentDegreeAsync(AddStudentDegreeDTO dto);
    }
}
