using CapstoneV4.Models.DomainModels;


namespace CapstoneV4.Models.DataLayer.Repositories
{
    public class StoreUoW : IStoreUoW
    {
        private CapstoneDB database;
        public StoreUoW(CapstoneDB db)
        {
            database = db;
        }

        private Repository<Courses> courseData;
        public Repository<Courses> Courses
        {
            get
            {
                if (courseData == null)
                {
                    courseData = new Repository<Courses>(database);
                }
                return courseData;
            }
        }


        private Repository<DomainModels.Program> programData;
        public Repository<DomainModels.Program> Programs
        {
            get
            {
                if (programData == null)
                {
                    programData = new Repository<DomainModels.Program>(database);
                }
                return programData;
            }
        }


        private Repository<CourseProgram> courseByProgramData;
        public Repository<CourseProgram> CourseProgram
        {
            get
            {
                if (courseByProgramData == null)
                {
                    courseByProgramData = new Repository<CourseProgram>(database);
                }
                return courseByProgramData;
            }
        }


        private Repository<Topics> topicData;
        public Repository<Topics> Topics
        {
            get
            {
                if (topicData == null)
                {
                    topicData = new Repository<Topics>(database);
                }
                return topicData;
            }
        }

        public void AddNewCoursePrograms(Courses course, int[] programids)
        {
            course.CourseProgram = programids.Select(i => new CourseProgram { Course = course, ProgramID = i }).ToList();
        }

        public void DeleteCurrentCoursePrograms(Courses course)
        {
            var currentPrograms = CourseProgram.List(new QueryOptions<CourseProgram>
            {
                Where = prgm => prgm.CourseID == course.CourseID
            });

            foreach (CourseProgram prgm in currentPrograms)
            {
                CourseProgram.Delete(prgm);
            }
        }

        public void Save() => database.SaveChanges();

    }
}
