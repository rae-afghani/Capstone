using Newtonsoft.Json;


//extensions of GRIDDTO.cs to add search filters but keep paging
namespace CapstoneV4.Models.DTOs
{
    public class BookGridDTO : GridDTO
    {

        [JsonIgnore]
        public const string DefaultFilter = "all";


        //creating filters
        public string Author { get; set; } = DefaultFilter;
        public string Genre { get; set; } = DefaultFilter;
        public string Price { get; set; } = DefaultFilter;

    }
}
