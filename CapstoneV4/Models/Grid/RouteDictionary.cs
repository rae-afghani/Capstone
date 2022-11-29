
using CapstoneV4.Models.DTOs;
using CapstoneV4.Models.ExtensionMethods;


namespace CapstoneV4.Models.Grid
{
    public class RouteDictionary : Dictionary<string, string>
    {
        //this method checks if the keyword is in the dictionary
        //otherwise returns null

        private string Get(string key) => ContainsKey(key) ? this[key] : null;


        public int PageNumber
        {
            get => Get(nameof(GridDTO.PageNumber)).ToInt();
            set => this[nameof(GridDTO.PageNumber)] = value.ToString();
        }
        public int PageSize
        {
            get => Get(nameof(GridDTO.PageSize)).ToInt();
            set => this[nameof(GridDTO.PageSize)] = value.ToString();
        }
        public string SortField
        {
            get => Get(nameof(GridDTO.SortField));
            set => this[nameof(GridDTO.SortField)] = value;
        }
        public string SortDirection
        {
            get => Get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }



        //this method will decide whether to order items in ascending or descending order by comparing 
        public void SetSortDirection(string fieldName, RouteDictionary current)
        {
            this[nameof(GridDTO.SortField)] = fieldName;

            if (current.SortField.EqualsNoCase(fieldName) && current.SortDirection == "asc")
                this[nameof(GridDTO.SortDirection)] = "desc";
            else
                this[nameof(GridDTO.SortDirection)] = "asc";
        }


        //creates method Clone to return a copy of the current route
        //dictionary object
        //purpose: in the instance of views with multiple pages/sorting uses routes to keep track of both current route values and to create the right values for each page

        public RouteDictionary Clone()
        {
            var clone = new RouteDictionary();
            foreach (var key in Keys)
            {
                clone.Add(key, this[key]);
            }
            return clone;
        }


        //setting up routes
        // get (check if not null) then set
        public string TopicFilter
        {
            get => Get(nameof(CourseGridDTO.Topic))?.Replace(FilterPrefix.Topic, "");
            set => this[nameof(CourseGridDTO.Topic)] = value;
        }
        public string TuitionFilter
        {
            get => Get(nameof(CourseGridDTO.Tuition))?.Replace(FilterPrefix.Tuition, "");
            set => this[nameof(CourseGridDTO.Tuition)] = value;
        }

        //program includes prefix, program id, slug
        //check if not null
        public string ProgramFilter
        {
            get
            {   //adds a '-' after each return of substring
                string s = Get(nameof(CourseGridDTO.ProgramType))?.Replace(FilterPrefix.ProgramType, "");
                int index = s?.IndexOf('-') ?? -1;
                return (index == -1) ? s : s.Substring(0, index);
            }
            set => this[nameof(CourseGridDTO.ProgramType)] = value;
        }

        //clears all filters via user action
        public void ClearFilters() => TopicFilter = TuitionFilter = ProgramFilter = CourseGridDTO.DefaultFilter;

    }
}
