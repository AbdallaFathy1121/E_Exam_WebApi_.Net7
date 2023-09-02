using Application.DTOs;
using Application.DTOs.Subject;

namespace Application.Interfaces.Services
{
    public interface ISubjectService
    {
        Task<MainResponse> GetAllSubjectsAsync();
        Task<MainResponse> GetSubjectByIdAsync(int id);
        Task<MainResponse> AddNewSubjectAsync(AddSubjectDTO dto);
        Task<MainResponse> UpdateSubjectByIdAsync(int id, UpdateSubjectDTO dto);
        Task<MainResponse> RemoveSubjectAsync(DeleteSubjectDTO dto);
    }
}
