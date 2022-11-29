using System.ComponentModel.DataAnnotations;

namespace CapstoneV4.Models.DomainModels
{
    public class Program
    {

        public int ProgramID { get; set; }

        [Required(ErrorMessage = "Please include a Program Type")]
        [MaxLength(50)]
        public string ProgramType { get; set; }

        [Required(ErrorMessage = "Please enter a Program Description")]
        [MaxLength(500)]
        public string ProgramDescription { get; set; }
        public string ProgramOverview => $"{ProgramType} {ProgramDescription}";
        public ICollection<CourseProgram> CourseProgram { get; set; }





    }
}
