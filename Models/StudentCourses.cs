using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherStudentPlatformAPI.Models
{
    public class StudentCourses
    {
        [Key]
        public string? StudentCoursesId { get; set; }

        [Required,ForeignKey("Student")]
        public required string StudentId { get; set; }

        [Required,ForeignKey("Course")]
        public required string CourseId { get; set;}


    }
}
