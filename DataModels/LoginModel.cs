using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TeacherStudentPlatformAPI.DataModels
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Email Address is required.")]
        [FromForm]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
        [FromForm]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

    }
}
