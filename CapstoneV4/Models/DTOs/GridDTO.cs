
//this data transfer object (DTO) is going to be used
//to transfer data from the route to controller via 
//model binding

//model binding is a simple way to transform the HTTP request
// in the query's form string
//to create a collection of action method parameters


namespace CapstoneV4.Models.DTOs
{
    public class GridDTO
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortField { get; set; }
        public string SortDirection { get; set; } = "asc";

    }
}
