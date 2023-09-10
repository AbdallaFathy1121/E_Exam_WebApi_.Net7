using Application.DTOs.Exam;
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Question;

namespace Application.Interfaces.Services
{
    public interface IQuestionService
    {
        Task<MainResponse> GetAllQuestionsByExamIdAsync(int examId);
        Task<MainResponse> GetQuestionByIdAsync(int id);
        Task<MainResponse> AddNewQuestionAsync(AddQuestionDTO dto);
        Task<MainResponse> UpdateQuestionByIdAsync(int id, UpdateQuestionDTO dto);
        Task<MainResponse> RemoveQuestionByIdAsync(int id);
    }
}
