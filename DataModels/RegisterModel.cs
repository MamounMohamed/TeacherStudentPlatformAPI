using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TeacherStudentPlatformAPI.DataModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [FromForm(Name = "Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [FromForm(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [FromForm(Name = "Password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Passwords don't match.")]
        [DataType(DataType.Password)]
        [FromForm(Name = "ConfirmPassword")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "UserType is required.")]
        [AllowedValues(["Teacher", "Student"], ErrorMessage = "UserType must be either 'Teacher' or 'Student'.")]
        [FromForm(Name = "UserType")]
        public string? UserType { get; set; }

        [FromForm(Name = "ProfilePicture")]
        public IFormFile? ProfilePicture { get; set; }
    }
}

