using Application.DTOs;
using Application.DTOs.User;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Constants;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly IJWTManagerRepository _jwtRepository;
        public UserService(
            UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, 
            SignInManager<User> signInManager,
            IJWTManagerRepository jWTManagerRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jwtRepository = jWTManagerRepository;
        }

        public async Task<MainResponse> GetAllUsersAsync()
        {
            MainResponse response = new MainResponse();
            try
            {
                var users = await _userManager.Users
                    .Select(a=> new UserDTO(a.Id, a.Email!))
                    .ToListAsync();

                response.IsSuccess = true;
                response.Data = users;
                return response;

            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<MainResponse> RegisterAsync(RegisterDTO dto)
        {
            MainResponse response = new MainResponse();
            try
            {
                if (dto.Password != dto.ConfirmPassword)
                {
                    response.Messages.Add("Confirm Password dosen't match Password");
                    return response;
                }

                var exists = await _userManager.FindByEmailAsync(dto.Email);
                if (exists is null)
                {
                    var createUser = new User
                    {
                        Email = dto.Email,
                        UserName = dto.Email,
                        IsTeacher = dto.IsTeacher
                    };
                    
                    IdentityResult result = await _userManager.CreateAsync(createUser, dto.Password);
                    if (result.Succeeded)
                    {
                        if (createUser.IsTeacher) 
                            await _userManager.AddToRoleAsync(createUser, Roles.Teacher);
                        
                        response.IsSuccess = true;
                        response.Messages!.Add("Add New User Successfully!");
                        response.Data = dto;
                        return response;
                    }
                    else
                    {
                        var errors = result.Errors.Select(a => a.Description);
                        response.Messages!.AddRange(errors);
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
                response.Messages!.Add(ex.Message.ToString());
                return response;
            }
        }

        public async Task<MainResponse> LoginAsync(LoginDTO dto)
        {
            MainResponse response = new MainResponse();
            try
            {
                var user = await _userManager.FindByEmailAsync(dto.Email);
                if (user is null)
                {
                    response.Messages.Add("Invalid Email");
                    return response;
                }

                bool isValidUser = await _userManager.CheckPasswordAsync(user, dto.Password);
                if (isValidUser)
                {
                    SignInResult result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, true);
                    if (result.Succeeded)
                    {
                        GenerateToken generateToken = _jwtRepository.Authenticate(user);
                        response.IsSuccess = true;
                        response.Messages.Add("Login Successfully!");
                        response.Data = generateToken;
                        return response;
                    }
                }
             
                response.Messages.Add("Invalid User");
                return response;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<MainResponse> DeleteUserByIdAsync(DeleteUserDTO dto)
        {
            MainResponse response = new MainResponse();
            try
            {
                var user = await _userManager.FindByIdAsync(dto.id);
                if (user is null)
                {
                    response.Messages.Add("Not found User with ID: " + dto.id);
                    return response;
                }
                else
                {
                    IdentityResult result = await _userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        response.IsSuccess = true;
                        response.Messages.Add("Delete User Successfully!");
                        response.Data = user.Email;
                        return response;
                    }
                    else
                    {
                        var errors = result.Errors.Select(a => a.Description);
                        response.Messages.AddRange(errors);
                        return response;
                    }
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
