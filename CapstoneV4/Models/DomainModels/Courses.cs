using System.ComponentModel.DataAnnotations;

namespace CapstoneV4.Models.DomainModels
{
    public class Courses
    {

        public int CourseID { get; set; }

        [Required(ErrorMessage = "Please enter course name")]
        [MaxLength(200)]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Please enter course description")]
        [MaxLength(500)]
        public string CourseDescription { get; set; }

        [Range(0.0, 1000.0, ErrorMessage = "Price must be between 0 and 1000.")]
        public double Tuition { get; set; }

        [Required(ErrorMessage = "Please select a topic")]
        public string TopicID { get; set; }


        public Topics Topic { get; set; }
        public ICollection<CourseProgram> CourseProgram { get; set; }
    }
}
