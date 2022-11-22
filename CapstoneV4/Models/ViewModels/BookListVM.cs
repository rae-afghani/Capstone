using CapstoneV4.Models.DomainModels;
using CapstoneV4.Models.Grid;
using System.Collections.Generic;


namespace CapstoneV4.Models.ViewModels
{
    public class BookListVM
    {
        public IEnumerable<Book> Books { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }

        //drop downs //


        //pricing
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public Dictionary<string, string> Prices =>
            new Dictionary<string, string>
            {
                { "under200", "Classes Under $200" },
                { "200to300", "Classes $200 to $300" },
                { "over300", "Classes over $300" }


            };

        public int[] PageSizes => new int[] { 10, 20, 30, 40, 50 };
    }
}
