using Application.DTOs;
using Application.DTOs.Exam;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Constants;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<MainResponse> GetAllExamsAsync()
        {
            MainResponse response = new MainResponse();
            try
            {
                var data = await _unitOfWork.ExamRepository.GetAllExamsAsync();

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

        public async Task<MainResponse> AddNewExamAsync(AddExamDTO dto)
        {
            MainResponse response = new MainResponse();
            try
            {
                var subjectLevel = await _unitOfWork.SubjectLevelRepository.GetFirstAsync(a => a.Id == dto.SubjectLevelId, new[] { "Subject" });
                if (subjectLevel is null)
                {
                    response.Messages.Add("Invalid SubjectLevel ID");
                    return response;
                }

                var getUserIdFromSubject = subjectLevel.Subject!.TeacherId;
                if (getUserIdFromSubject != dto.TeacherId)
                {
                    response.Messages.Add("Invalid User ID");
                    return response;
                }

                Exam exam = new Exam
                {
                    ExamName = dto.ExamName,
                    StartDateTime = dto.StartDateTime,
                    EndDateTime = dto.EndDateTime,
                    SubjectLevelId = dto.SubjectLevelId,
                    UserId = dto.TeacherId
                };

                await _unitOfWork.ExamRepository.AddAsync(exam);
                await _unitOfWork.Complete();

                response.IsSuccess = true;
                response.Messages.Add("Add New Exam Successfully!");
                response.Data = dto;
                return response;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<MainResponse> GetExamByIdAsync(int id)
        {
            MainResponse response = new MainResponse();
            try
            {
                var data = await _unitOfWork.ExamRepository.GetExamByIdAsync(id);
                if (data is null)
                {
                    response.Messages.Add("Not found Exam with ID: " + id);
                    return response;
                }

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

        public async Task<MainResponse> UpdateExamByIdAsync(int id, UpdateExamDTO dto)
        {
            MainResponse response = new MainResponse();
            try
            {
                var exam = await _unitOfWork.ExamRepository.GetFirstAsync(a => a.Id == id);
                if (exam is null)
                {
                    response.Messages.Add("Not found Exam with ID: " + id);
                    return response;
                }

                var subjectLevel = await _unitOfWork.SubjectLevelRepository.GetFirstAsync(a => a.Id == dto.SubjectLevelId, new[] { "Subject" });
                if (subjectLevel is null)
                {
                    response.Messages.Add("Invalid SubjectLevel ID");
                    return response;
                }

                var getUserIdFromSubject = subjectLevel.Subject!.TeacherId;
                if (getUserIdFromSubject != dto.TeacherId)
                {
                    response.Messages.Add("Invalid User ID");
                    return response;
                }

                exam.ExamName = dto.ExamName;
                exam.StartDateTime = dto.StartDateTime;
                exam.EndDateTime = dto.EndDateTime;
                exam.SubjectLevelId = dto.SubjectLevelId;
                exam.UserId = dto.TeacherId;

                _unitOfWork.ExamRepository.Update(exam);
                await _unitOfWork.Complete();

                response.IsSuccess = true;
                response.Messages.Add("Update Exam Successfully!");
                response.Data = dto;
                return response;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<MainResponse> RemoveExamByIdAsync(int id)
        {
            MainResponse response = new MainResponse();
            try
            {
                var data = await _unitOfWork.ExamRepository.GetFirstAsync(a => a.Id == id);
                if (data is null)
                {
                    response.Messages.Add("Not found Exam with ID: " + id);
                    return response;
                }

                await _unitOfWork.ExamRepository.Delete(data);
                await _unitOfWork.Complete();

                response.IsSuccess = true;
                response.Messages.Add("Delete Exam Successfully!");
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
