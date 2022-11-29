using CapstoneV4.Models.DomainModels;

namespace CapstoneV4.Models.DTOs
{
    public class CoursesDTO
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; private set; }
        public double Tuition { get; set; }
        public Dictionary<int, string> Programs { get; set; }

        public void Load(Courses course)
        {
            CourseID = course.CourseID;
            CourseName = course.CourseName;
            CourseDescription = course.CourseDescription;
            Tuition = course.Tuition;
            Programs = new Dictionary<int, string>();

            foreach (CourseProgram prgm in course.CourseProgram)
            {
                Programs.Add(prgm.ProgramID, prgm.Program.ProgramOverview);
            }
        }
    }
}
