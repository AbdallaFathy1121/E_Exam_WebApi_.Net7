using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
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

        public Task<MainResponse> GetSubjectLevelsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MainResponse> GetSubjectLevelsByLevelNameAsync(string levelName)
        {
            throw new NotImplementedException();
        }

        public Task<MainResponse> GetSubjectLevelsBySubjectNameAsync(string subjectName)
        {
            throw new NotImplementedException();
        }
    }
}
