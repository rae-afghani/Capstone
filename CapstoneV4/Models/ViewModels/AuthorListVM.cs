using CapstoneV4.Models.DomainModels;
using CapstoneV4.Models.Grid;
using System.Collections.Generic;

namespace CapstoneV4.Models.ViewModels
{
    public class AuthorListVM
    {
        public IEnumerable<Author> Authors { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
    }
}
