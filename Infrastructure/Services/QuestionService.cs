using Application.DTOs;
using Application.DTOs.Question;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<MainResponse> AddNewQuestionAsync(AddQuestionDTO dto)
        {
            MainResponse response = new MainResponse();
            try
            {
                var exam = await _unitOfWork.ExamRepository.GetFirstAsync(a => a.Id == dto.ExamId);
                if (exam is null)
                {
                    response.Messages.Add("Invalid Exam ID");
                    return response;
                }

                Question question = new Question
                {
                    ExamId = dto.ExamId,
                    QuestionName = dto.QuestionName,
                    A1 = dto.A1,
                    A2 = dto.A2,
                    A3 = dto.A3,
                    A4 = dto.A4,
                    CorrectAnswer = dto.CorrectAnswer
                };

                await _unitOfWork.QuestionRepository.AddAsync(question);
                await _unitOfWork.Complete();

                response.IsSuccess = true;
                response.Messages.Add("Add New Question Successfully!");
                response.Data = question;
                return response;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<MainResponse> GetAllQuestionsByExamIdAsync(int examId)
        {
            MainResponse response = new MainResponse();
            try
            {
                var exam = await _unitOfWork.ExamRepository.GetFirstAsync(a => a.Id == examId);
                if (exam is null)
                {
                    response.Messages.Add("Invalid Exam ID");
                    return response;
                }

                var data = await _unitOfWork.QuestionRepository.GetWhereAsync(a => a.ExamId == examId, null);

                response.IsSuccess = true;
                response.Data = data;
                return response;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<MainResponse> GetQuestionByIdAsync(int id)
        {
            MainResponse response = new MainResponse();
            try
            {
                var question = await _unitOfWork.QuestionRepository.GetFirstAsync(a => a.Id == id);
                if (question is null)
                {
                    response.Messages.Add("Invalid question ID");
                    return response;
                }

                response.IsSuccess = true;
                response.Data = question;
                return response;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<MainResponse> UpdateQuestionByIdAsync(int id, UpdateQuestionDTO dto)
        {
            MainResponse response = new MainResponse();
            try
            {
                var question = await _unitOfWork.QuestionRepository.GetFirstAsync(a => a.Id == id);
                if (question is null)
                {
                    response.Messages.Add("Invalid question ID");
                    return response;
                }

                question.ExamId = dto.ExamId;
                question.QuestionName = dto.QuestionName;
                question.A1 = dto.A1;
                question.A2 = dto.A2;
                question.A3 = dto.A3;
                question.A4 = dto.A4;
                question.CorrectAnswer = dto.CorrectAnswer;

                _unitOfWork.QuestionRepository.Update(question);
                await _unitOfWork.Complete();

                response.IsSuccess = true;
                response.Messages.Add("Update Question Successfully");
                response.Data = question;
                return response;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<MainResponse> RemoveQuestionByIdAsync(int id)
        {
            MainResponse response = new MainResponse();
            try
            {
                var question = await _unitOfWork.QuestionRepository.GetFirstAsync(a => a.Id == id);
                if (question is null)
                {
                    response.Messages.Add("Invalid question ID");
                    return response;
                }

                await _unitOfWork.QuestionRepository.Delete(question);
                await _unitOfWork.Complete();

                response.IsSuccess = true;
                response.Messages.Add("Delete Question Successfully");
                return response;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }
    }
}
