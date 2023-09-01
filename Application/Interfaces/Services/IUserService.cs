using Application.DTOs;
using Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<MainResponse> RegisterAsync(RegisterDTO dto);
        Task<MainResponse> LoginAsync(LoginDTO dto);
        Task<MainResponse> GetAllUsersAsync();
        Task<MainResponse> DeleteUserByIdAsync(DeleteUserDTO dto);
    }
}
