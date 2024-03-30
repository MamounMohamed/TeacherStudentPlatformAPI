namespace TeacherStudentPlatformAPI.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class Teacher

    {
        [Key]
        [ForeignKey("User")]

        public string? TeacherId { get; set; } 

        [DefaultValue(0)]
        public int NumOfWatchers { get; set; }

        [DefaultValue(0)]
        public int NumUploadedVideos { get; set; }

    }
}
