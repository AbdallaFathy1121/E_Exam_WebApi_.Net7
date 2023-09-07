using Application.DTOs.Level;
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Exam;

namespace Application.Interfaces.Services
{
    public interface IExamService
    {
        Task<MainResponse> GetAllExamsAsync();
        Task<MainResponse> GetExamByIdAsync(int id);
        Task<MainResponse> AddNewExamAsync(AddExamDTO dto);
        Task<MainResponse> UpdateExamByIdAsync(int id, UpdateExamDTO dto);
        Task<MainResponse> RemoveExamByIdAsync(int id);
    }
}
