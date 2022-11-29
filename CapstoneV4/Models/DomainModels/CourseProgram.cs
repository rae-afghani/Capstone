namespace CapstoneV4.Models.DomainModels
{
    public class CourseProgram
    {
        public int CourseID { get; set; }

        public int ProgramID { get; set; }

        public Program Program { get; set; }
        public Courses Course { get; set; }

    }
}
