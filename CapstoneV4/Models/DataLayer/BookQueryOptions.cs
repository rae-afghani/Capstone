using CapstoneV4.Models.DomainModels;
using CapstoneV4.Models.ExtensionMethods;
using CapstoneV4.Models.Grid;

namespace CapstoneV4.Models.DataLayer
{
    //extends queryoptions(book)
    //to add a sorting/filter bethod that adds
    //code specific to app
    public class BookQueryOptions : QueryOptions<Book>
    {
        public void SortFilter(BookGridBuilder builder)
        {
            //adding filters
            if (builder.FilterByGenre)
                Where = b => b.GenreId == builder.CurrentRoute.GenreFilter;

            if (builder.FilterByPrice)
            {
                if (builder.CurrentRoute.PriceFilter == "under200")
                    Where = b => b.Price < 200;
                else if (builder.CurrentRoute.PriceFilter == "200to300")
                    Where = b => b.Price >= 200 && b.Price <= 300;
                else if (builder.CurrentRoute.PriceFilter == "over300")
                    Where = b => b.Price > 300;
            }

            if (builder.FilterByAuthor)
            {
                var id = builder.CurrentRoute.AuthorFilter.ToInt();
                //if id exists
                if (id > 0)
                    Where = b => b.BookAuthor.Any(ba => ba.Author.AuthorID== id);
            }

            //adding sorts
            if (builder.SortByGenre)
                OrderBy = b => b.Genre.Name;
            else if (builder.SortByPrice)
                OrderBy = b => b.Price;
            else
                OrderBy = b => b.Title;

        }


    }
}
