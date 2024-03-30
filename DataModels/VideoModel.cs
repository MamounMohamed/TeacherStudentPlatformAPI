using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TeacherStudentPlatformAPI.DataModels
{
    public class VideoModel

    {
        [Required(ErrorMessage="Name is Required"), Column(TypeName = "nvarchar(MAX)") , FromForm ]
        public required string VideoName { get; set; }

        [AllowNull, Column(TypeName = "nvarchar(MAX)"), FromForm]
        public string? VideoDescription { get; set; }

        [ForeignKey("Course") , Required(ErrorMessage = "Course is Required"), FromForm]
        public required string CourseId { get; set; } // Foreign Key to Channel

        [AllowNull]
        public IFormFile? VideoThumbnailFile { get; set; }

        [Required(ErrorMessage = "Video is Required"), FromForm]
        public  required IFormFile VideoFile { get; set; }

    }
}
