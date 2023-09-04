using Application.DTOs;
using Application.DTOs.SubjectLevel;
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
    public class SubjectLevelService : ISubjectLevelService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubjectLevelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<MainResponse> GetAllSubjectLevelsAsync()
        {
            MainResponse response = new MainResponse();
            try
            {
                var data = await _unitOfWork.SubjectLevelRepository.GetAllSubjectLevelsAsync();

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

        public async Task<MainResponse> GetSubjectLevelByIdAsync(int id)
        {
            MainResponse response = new MainResponse();
            try
            {
                var subjectLevel = await _unitOfWork.SubjectLevelRepository.GetFirstAsync(a => a.Id == id, new[] { "Subject", "Level" });

                response.IsSuccess = true;
                response.Data = subjectLevel;
                return response;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<MainResponse> GetSubjectLevelsByLevelIdAsync(int levelId)
        {
            MainResponse response = new MainResponse();
            try
            {
                var data = await _unitOfWork.SubjectLevelRepository.GetWhereAsync(a => a.LevelId == levelId, null, new[] { "Level", "Subject" });

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

        public async Task<MainResponse> GetSubjectLevelsBySubjectIdAsync(int subjectId)
        {
            MainResponse response = new MainResponse();
            try
            {
                var data = await _unitOfWork.SubjectLevelRepository.GetWhereAsync(a => a.SubjectId == subjectId, null, new[] { "Level", "Subject" });

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

        public async Task<MainResponse> AddSubjectLevelAsync(AddSubjectLevelDTO dto)
        {
            MainResponse response = new MainResponse();
            try
            {
                var findLevelById = await _unitOfWork.LevelRepository.GetFirstAsync(a => a.Id == dto.LevelId);
                if (findLevelById is null)
                {
                    response.Messages.Add("Not Found Level with ID:" +  dto.LevelId);
                    return response;
                }

                var findSubjectById = await _unitOfWork.SubjectRepository.GetFirstAsync(a => a.Id == dto.SubjectId);
                if (findSubjectById is null)
                {
                    response.Messages.Add("Not Found Subject with ID:" + dto.SubjectId);
                    return response;
                }

                var model = new SubjectLevel
                {
                    LevelId = dto.LevelId,
                    SubjectId = dto.SubjectId
                };

                await _unitOfWork.SubjectLevelRepository.AddAsync(model);
                await _unitOfWork.Complete();

                response.IsSuccess = true;
                response.Messages.Add("Add New SubjectLevel Successfully!");
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
