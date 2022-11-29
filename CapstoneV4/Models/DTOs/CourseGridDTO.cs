using Newtonsoft.Json;


//extensions of GRIDDTO.cs to add search filters but keep paging
namespace CapstoneV4.Models.DTOs
{
    public class CourseGridDTO : GridDTO
    {

        [JsonIgnore]
        public const string DefaultFilter = "all";


        //creating filters
        public string ProgramType { get; set; } = DefaultFilter;
        public string Topic { get; set; } = DefaultFilter;
        public string Tuition { get; set; } = DefaultFilter;

    }
}
