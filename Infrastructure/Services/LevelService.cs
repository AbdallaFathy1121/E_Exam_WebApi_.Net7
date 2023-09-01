using Application.DTOs;
using Application.DTOs.Level;
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
    public class LevelService : ILevelService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LevelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<MainResponse> GetAllLevelsAsync()
        {
            MainResponse response = new MainResponse();
            try
            {
                var getLevels = await _unitOfWork.LevelRepository.GetAllAsync();
                response.IsSuccess = true;
                response.Data = getLevels;

                return response;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }
        
        public async Task<MainResponse> GetLevelByIdAsync(int id)
        {
            MainResponse response = new MainResponse();
            try
            {
                var level = await _unitOfWork.LevelRepository.GetFirstAsync(a=>a.Id == id);
                if (level is not null)
                {
                    response.IsSuccess = true;
                    response.Data = level;
                    return response;
                }
                else
                {
                    response.Messages.Add("Not found level with ID: " + id);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<MainResponse> AddNewLevelAsync(AddLevelDTO dto)
        {
            MainResponse response = new MainResponse();
            try
            {
                var getLevelByName = await _unitOfWork.LevelRepository.GetFirstAsync(a => a.LevelName == dto.Name);
                if (getLevelByName is null)
                {
                    var level = new Level
                    {
                        LevelName = dto.Name
                    };

                    var result = await _unitOfWork.LevelRepository.AddAsync(level);
                    await _unitOfWork.Complete();

                    response.IsSuccess = true;
                    response.Messages.Add("Add New Level Successfully!");
                    response.Data = dto;

                    return response;
                }
                else
                {
                    response.Messages.Add("This name already exists");
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<MainResponse> UpdateLevelByIdAsync(int id, UpdateLevelDTO dto)
        {
            MainResponse response = new MainResponse();
            try
            {
                var level = await _unitOfWork.LevelRepository.GetFirstAsync(a => a.Id == id);
                if (level is not null && level.LevelName != dto.Name)
                {
                    level.LevelName = dto.Name;

                    _unitOfWork.LevelRepository.Update(level);
                    await _unitOfWork.Complete();

                    response.IsSuccess = true;
                    response.Messages.Add("Update Level Successfully!");
                    response.Data = level;
                    return response;
                }
                else
                {
                    if (level is null)
                        response.Messages.Add("Not found Level with ID: " + id);
                    else
                        response.Messages.Add("This Name is already exists");

                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<MainResponse> RemoveLevelByIdAsync(DeleteLevelDTO dto)
        {
            MainResponse response = new MainResponse();
            try
            {
                var level = await _unitOfWork.LevelRepository.GetFirstAsync(a => a.Id == dto.Id);
                if (level is not null)
                {
                    await _unitOfWork.LevelRepository.Delete(level);
                    await _unitOfWork.Complete();

                    response.IsSuccess = true;
                    response.Messages.Add("Remove Level Successfully!");
                    return response;
                }
                else
                {
                    response.Messages.Add("Not Found Level with ID: " + dto.Id);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }
    }
}
