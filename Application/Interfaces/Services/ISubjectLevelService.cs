using Application.DTOs;
using Application.DTOs.SubjectLevel;
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
        Task<MainResponse> GetSubjectLevelByIdAsync(int id);
        Task<MainResponse> GetSubjectLevelsByLevelIdAsync(int LevelId);
        Task<MainResponse> GetSubjectLevelsBySubjectIdAsync(int subjectId);
        Task<MainResponse> AddSubjectLevelAsync(AddSubjectLevelDTO dto);
        Task<MainResponse> UpdateSubjectLevelAsync(int id, UpdateSubjectLevelDTO dto);
        Task<MainResponse> RemoveSubjectLevelAsync(int id);
    }
}
