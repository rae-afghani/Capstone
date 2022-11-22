
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
        public string GenreFilter
        {
            get => Get(nameof(BookGridDTO.Genre))?.Replace(FilterPrefix.Genre, "");
            set => this[nameof(BookGridDTO.Genre)] = value;
        }
        public string PriceFilter
        {
            get => Get(nameof(BookGridDTO.Price))?.Replace(FilterPrefix.Price, "");
            set => this[nameof(BookGridDTO.Price)] = value;
        }

        //author includes prefix, author id, slug
        //check if not null
        public string AuthorFilter
        {
            get
            {   //adds a '-' after each return of substring (author id, book title, author name
                string s = Get(nameof(BookGridDTO.Author))?.Replace(FilterPrefix.Author, "");
                int index = s?.IndexOf('-') ?? -1;
                return (index == -1) ? s : s.Substring(0, index);
            }
            set => this[nameof(BookGridDTO.Author)] = value;
        }

        //clears all filters via user action
        public void ClearFilters() => GenreFilter = PriceFilter = AuthorFilter = BookGridDTO.DefaultFilter;

    }
}
