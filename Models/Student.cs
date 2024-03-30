using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace TeacherStudentPlatformAPI.Models
{
    public class Student 
    {
        [Key]
        [ForeignKey("User")]
        public string? StudentId{ get; set; } // Foreign Key to User, also Primary Key
        


    }
}
