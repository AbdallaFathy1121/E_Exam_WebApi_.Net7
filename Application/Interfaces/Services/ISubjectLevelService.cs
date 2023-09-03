using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ISubjectLevelService
    {
        Task<MainResponse> GetAllSubjectLevelsAsync();
        Task<MainResponse> GetSubjectLevelsByIdAsync(int id);
        Task<MainResponse> GetSubjectLevelsByLevelNameAsync(string levelName);
        Task<MainResponse> GetSubjectLevelsBySubjectNameAsync(string subjectName);
    }
}
