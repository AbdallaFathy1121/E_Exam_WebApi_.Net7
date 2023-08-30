using Application.DTOs;
using Application.DTOs.User;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        public UserService(
            UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, 
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }


        public async Task<MainResponse> CreateNewUser(RegisterDTO dto)
        {
            MainResponse response = new MainResponse();
            try
            {
                var exists = await _userManager.FindByEmailAsync(dto.Email);
                if (exists is null)
                {
                    var createUser = new User
                    {
                        Email = dto.Email,
                        UserName = dto.Email
                    };
                    
                    IdentityResult result = await _userManager.CreateAsync(createUser, dto.Password);
                    if (result.Succeeded)
                    {
                        response.IsSuccess = true;
                        response.Messages!.Add("Add New User Successfully!");
                        response.Data = createUser;
                        return response;
                    }
                    else
                    {
                        var errors = result.Errors.Select(a => a.Description);
                        foreach (var error in errors)
                        {
                            response.Messages!.Add(error);
                        }
                        return response;
                    }
                }
                else
                {
                    response.Messages!.Add("Email already Exists");
                    return response;
                }
			}
			catch (Exception ex)
			{
                response.IsSuccess = false;
                response.Messages!.Add(ex.Message.ToString());
                return response;
            }
        }
    }
}
