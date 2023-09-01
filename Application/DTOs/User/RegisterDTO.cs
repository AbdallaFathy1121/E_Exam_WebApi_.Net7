using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.User
{
    public record RegisterDTO
    (
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        string Email,

        [Required(ErrorMessage = "Password is Required")]
        string Password,

        string ConfirmPassword,

        bool IsTeacher
    );
}
