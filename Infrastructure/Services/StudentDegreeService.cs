using Application.DTOs;
using Application.DTOs.StudentDegree;
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
    public class StudentDegreeService : IStudentDegreeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentDegreeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<MainResponse> AddStudentDegreeAsync(AddStudentDegreeDTO dto)
        {
            MainResponse response = new MainResponse();
            try
            {
                var getStudentDegree = await _unitOfWork.StudentDegreeRepository
                    .GetFirstAsync(a => a.UserId == dto.UserId && a.SubjectId == dto.SubjectId);
                if (getStudentDegree is null)
                {
                    var getSubject = await _unitOfWork.SubjectRepository.GetFirstAsync(a => a.Id == dto.SubjectId);
                    if (getSubject is not null)
                    {
                        StudentDegree model = new StudentDegree();
                        model.UserId = dto.UserId;
                        model.SubjectId = dto.SubjectId;
                        model.Degree = dto.Degree;
                        model.ExamDegree = dto.ExamDegree;

                        await _unitOfWork.StudentDegreeRepository.AddAsync(model);
                        await _unitOfWork.Complete();

                        response.IsSuccess = true;
                        response.Data = new { dto.Degree, dto.ExamDegree};
                        response.Messages.Add("Finish Exam Successfully!");
                        return response;
                    }
                    else
                    {
                        response.Messages.Add("Invalid Subject ID");
                        return response;
                    }
                }
                else
                {
                    response.Messages.Add("This student took the exam before");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<MainResponse> GetAllStudentDegreesAsync()
        {
            MainResponse response = new MainResponse();
            try
            {
                var data = await _unitOfWork.StudentDegreeRepository.GetAllStudentDegreesAsync();

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

        public async Task<MainResponse> GetStudentDegreeByUserIdAndSubjectIDAsync(string userId, int subjectId)
        {
            MainResponse response = new MainResponse();
            try
            {
                var data = await _unitOfWork.StudentDegreeRepository
                    .GetFirstAsync(a => a.UserId == userId && a.SubjectId == subjectId, new[] { "User", "Subject" });

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

        public async Task<MainResponse> GetStudentDegreesBySubjectIdAsync(int subjectId)
        {
            MainResponse response = new MainResponse();
            try
            {
                var data = await _unitOfWork.StudentDegreeRepository
                    .GetWhereAsync(a => a.SubjectId == subjectId, null, new[] { "User", "Subject" });

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

        public async Task<MainResponse> GetStudentDegreesByUserIdAsync(string userId)
        {
            MainResponse response = new MainResponse();
            try
            {
                var data = await _unitOfWork.StudentDegreeRepository
                    .GetWhereAsync(a => a.UserId == userId, null, new[] { "User", "Subject" });

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
    }
}
