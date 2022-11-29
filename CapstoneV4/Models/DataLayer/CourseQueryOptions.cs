using CapstoneV4.Models.DomainModels;
using CapstoneV4.Models.ExtensionMethods;
using CapstoneV4.Models.Grid;

namespace CapstoneV4.Models.DataLayer
{
    //extends queryoptions(book)
    //to add a sorting/filter bethod that adds
    //code specific to app
    public class CourseQueryOptions : QueryOptions<Courses>
    {
        public void SortFilter(CoursesGridBuilder builder)
        {
            //adding filters
            if (builder.FilterByTopic)
                Where = c => c.TopicID == builder.CurrentRoute.TopicFilter;

            if (builder.FilterByTuition)
            {
                if (builder.CurrentRoute.TuitionFilter == "under200")
                    Where = c => c.Tuition < 200;
                else if (builder.CurrentRoute.TuitionFilter == "200to300")
                    Where = c => c.Tuition >= 200 && c.Tuition <= 300;
                else if (builder.CurrentRoute.TuitionFilter == "over300")
                    Where = c => c.Tuition > 300;
            }

            if (builder.FilterByProgram)
            {
                var id = builder.CurrentRoute.ProgramFilter.ToInt();
                //if id exists
                if (id > 0)
                    Where = c => c.CourseProgram.Any(prgm => prgm.Program.ProgramID == id);
            }

            //adding sorts
            if (builder.SortByTopic)
                OrderBy = c => c.Topic.Name;
            else if (builder.SortByTuition)
                OrderBy = c => c.Tuition;
            else
                OrderBy = c => c.CourseName;

        }


    }
}
