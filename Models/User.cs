namespace TeacherStudentPlatformAPI.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    public class User : IdentityUser
    {
        [MaxLength(100)][Required]
        public string? Name { get; set; }
        [Required , AllowedValues(["Teacher" , "Student"])] 
        public required string UserType { get; set; } 
        public string? ProfilePicture { get; set; }
    }
}
