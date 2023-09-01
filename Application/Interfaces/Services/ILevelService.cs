using Application.DTOs;
using Application.DTOs.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ILevelService
    {
        Task<MainResponse> GetAllLevelsAsync();
        Task<MainResponse> GetLevelByIdAsync(int id);
        Task<MainResponse> AddNewLevelAsync(AddLevelDTO dto);
        Task<MainResponse> UpdateLevelByIdAsync(int id, UpdateLevelDTO dto);
        Task<MainResponse> RemoveLevelByIdAsync(DeleteLevelDTO dto);
    }
}
