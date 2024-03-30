namespace TeacherStudentPlatformAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;

    public class Video
    {
        [Key]
        public string? VideoId { get; set; } // Primary Key

        [Required , Column(TypeName = "nvarchar(MAX)")]
        public required string VideoName { get; set; }

        [AllowNull , Column(TypeName ="nvarchar(MAX)")]
        public string? VideoDescription { get; set; }

        [ForeignKey("Course"),Required]
        public required string CourseId { get; set; } // Foreign Key to Channel
        
        [AllowNull]
        public  string? VideoThumbnail { get; set; }
        
        [Required]
        public required string VideoURI { get; set; }




    }
}
