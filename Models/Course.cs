using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherStudentPlatformAPI.Models
{
    public class Course
    {
        [Key]
        public string?CourseId { get; set; }

        [Required,ForeignKey("Teacher")]
        public required string TeacherId { get; set; }
        
        [Required ,Column(TypeName ="nvarchar(50)")]
        public required string CourseName { get; set; }
        
        [Required, Column(TypeName = "nvarchar(MAX)")]
        public required string CourseDescription { get; set;}
        
        [Required, Column(TypeName = "nvarchar(50)")]
        public required string CourseVerificationCode { get; set; }

    }
}
