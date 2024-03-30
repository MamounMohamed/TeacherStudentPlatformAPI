namespace TeacherStudentPlatformAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WatchList
    {
        [Key]
        public string? WatchListId { get; set; } // Primary Key

        [Required,ForeignKey("Student")]
        public required string StudentId { get; set; } // Foreign Key to User

        [Required,ForeignKey("Video")]
        public required string VideoId { get; set; } // Foreign Key to Video

    }
}
