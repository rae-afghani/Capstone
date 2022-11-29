using CapstoneV4.Models.DomainModels;
using CapstoneV4.Models.DTOs;
using CapstoneV4.Models.ExtensionMethods;

namespace CapstoneV4.Models.Grid
{
    public class CoursesGridBuilder : GridBuilder
    {
        //book specific filtering and sorting

        //pulls current route data
        public CoursesGridBuilder(ISession session) : base(session) { }
        public CoursesGridBuilder(ISession session, CourseGridDTO coursedto, string defaultSortFilter) : base(session, coursedto, defaultSortFilter)
        {
            //route segments, add prefixes on inital load
            //if true, then it is the initial load
            bool InitialLoad = coursedto.Topic.IndexOf(FilterPrefix.Topic) == -1;

            //if initial load is true, add filter prefix to slug
            //if false, no changes will be made
            Routes.ProgramFilter = (InitialLoad) ? FilterPrefix.ProgramType + coursedto.ProgramType : coursedto.ProgramType;

            Routes.TopicFilter = (InitialLoad) ? FilterPrefix.Topic + coursedto.Topic : coursedto.Topic;

            Routes.TuitionFilter = (InitialLoad) ? FilterPrefix.Tuition + coursedto.Tuition : coursedto.Tuition;


            //after bool testing, saves the route segment
            SaveRouteEvent();

        }

        //loading new route segments and adding filter prefixes when necessary
        //for example, in the case that the user clears all filters then adds one, only that specific segment will be appended to the slug
        public void ReloadRoutes(string[] filter, DomainModels.Program a)
        {
            if (a == null)
                Routes.ProgramFilter = FilterPrefix.ProgramType + filter[0];
            else
                Routes.ProgramFilter = FilterPrefix.ProgramType + filter[0] + "-" + a.ProgramType.Slug();


            Routes.TopicFilter = FilterPrefix.Topic + filter[1];
            Routes.TuitionFilter = FilterPrefix.Tuition + filter[2];
        }

        //clears appended filters on slug (pulls from route dictionary)
        public void ClearFilters() => Routes.ClearFilters();

        //filterbys
        string d = CourseGridDTO.DefaultFilter;
        public bool FilterByProgram => Routes.ProgramFilter != d;
        public bool FilterByTopic => Routes.TopicFilter != d;
        public bool FilterByTuition => Routes.TuitionFilter != d;


        //sorts
        public bool SortByTopic => Routes.SortField.EqualsNoCase(nameof(Topics));
        public bool SortByTuition => Routes.SortField.EqualsNoCase(nameof(Courses.Tuition));

    }
}
