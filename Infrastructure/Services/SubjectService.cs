using Application.DTOs;
using Application.DTOs.Subject;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Constants;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        public SubjectService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        public async Task<MainResponse> GetAllSubjectsAsync()
        {
            MainResponse response = new MainResponse();
            try
            {
                var subjects = await _unitOfWork.SubjectRepository.GetAllSubjectsAsync();
                
                response.IsSuccess = true;
                response.Data = subjects;
                return response;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<MainResponse> GetSubjectByIdAsync(int id)
        {
            MainResponse response = new MainResponse();
            try
            {
                var subject = await _unitOfWork.SubjectRepository.GetSubjectByIdAsync(id);

                response.IsSuccess = true;
                response.Data = subject;
                return response;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<MainResponse> AddNewSubjectAsync(AddSubjectDTO dto)
        {
            MainResponse response = new MainResponse();
            try
            {
                var findSubjectByName = await _unitOfWork.SubjectRepository.GetFirstAsync(a => a.Name == dto.Name);
                var findUserById = await _userManager.FindByIdAsync(dto.TeacherId);

                if (findSubjectByName is null && findUserById is not null)
                {
                    bool isInRoleTeacher = await _userManager.IsInRoleAsync(findUserById, Roles.Teacher);
                    if (isInRoleTeacher)
                    {

                        Subject subject = new Subject
                        {
                            Name = dto.Name,
                            TeacherId = dto.TeacherId
                        };

                        var result = await _unitOfWork.SubjectRepository.AddAsync(subject);
                        await _unitOfWork.Complete();

                        response.IsSuccess = true;
                        response.Messages.Add("Add New Subject Successfully!");
                        response.Data = result.Id;
                    }
                    else
                    {
                        response.Messages.Add("This User is not in role Teacher");
                    }
                    
                    return response;
                }
                else
                {
                    if (findUserById is null)
                        response.Messages.Add("Not found UserId");
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

        public async Task<MainResponse> UpdateSubjectByIdAsync(int id, UpdateSubjectDTO dto)
        {
            MainResponse response = new MainResponse();
            try
            {
                var subject = await _unitOfWork.SubjectRepository.GetFirstAsync(a=>a.Id == id && a.Name != dto.Name);
                var findUserById = await _userManager.FindByIdAsync(dto.TeacherId);

                if (subject is not null && findUserById is not null)
                {
                    bool isInRoleTeacher = await _userManager.IsInRoleAsync(findUserById, Roles.Teacher);
                    if (isInRoleTeacher)
                    {
                        subject.TeacherId = dto.TeacherId;
                        subject.Name = dto.Name;

                        var result = _unitOfWork.SubjectRepository.Update(subject);
                        await _unitOfWork.Complete();

                        response.IsSuccess = true;
                        response.Messages.Add("Update Subject Successfully!");
                        response.Data = dto;
                    }
                    else
                    {
                        response.Messages.Add("This User is not in role Teacher");
                    }

                    return response;
                }
                else
                {
                    if (findUserById is null)
                        response.Messages.Add("Not found User with ID");
                    else
                        response.Messages.Add("Not Found Subject");

                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<MainResponse> RemoveSubjectAsync(DeleteSubjectDTO dto)
        {
            MainResponse response = new MainResponse();
            try
            {
                var subject = await _unitOfWork.SubjectRepository.GetFirstAsync(a => a.Id == dto.Id && a.TeacherId == dto.TeacherId);
                if (subject is not null)
                {
                    await _unitOfWork.SubjectRepository.Delete(subject);
                    await _unitOfWork.Complete();

                    response.IsSuccess = true;
                    response.Messages.Add("Delete Subject Successfully!");

                    return response;
                }
                else
                {
                    response.Messages.Add("Not found Subject");
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
