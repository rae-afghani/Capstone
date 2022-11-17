using CapstoneV4.Models.DomainModels;
using CapstoneV4.Models.DTOs;
using CapstoneV4.Models.ExtensionMethods;
using CapstoneV4.Models.Grid;
using Microsoft.AspNetCore.Http;

namespace CapstoneV4.Models.Grid
{
    public class BookGridBuilder : GridBuilder
    {
        //book specific filtering and sorting

        //pulls current route data
        public BookGridBuilder(ISession session) : base(session) { }
        public BookGridBuilder(ISession session, BookGridDTO bdto, string defaultSortFilter) :base(session, bdto, defaultSortFilter)
        {
            //route segments, add prefixes on inital load
            //if true, then it is the initial load
            bool InitialLoad = bdto.Genre.IndexOf(FilterPrefix.Genre) == -1;

            //if initial load is true, add filter prefix to slug
            //if false, no changes will be made
            Routes.AuthorFilter = (InitialLoad) ? FilterPrefix.Author + bdto.Author : bdto.Author;

            Routes.GenreFilter = (InitialLoad) ? FilterPrefix.Genre + bdto.Genre : bdto.Genre;

            Routes.PriceFilter = (InitialLoad) ? FilterPrefix.Price + bdto.Price : bdto.Price;


            //after bool testing, saves the route segment
            SaveRouteEvent();

        }

        //loading new route segments and adding filter prefixes when necessary
        //for example, in the case that the user clears all filters then adds one, only that specific segment will be appended to the slug
        public void ReloadRoutes(string[] filter, Author a)
        {
            if (a == null)
                Routes.AuthorFilter = FilterPrefix.Author + filter[0];
            else
                Routes.AuthorFilter = FilterPrefix.Author + filter[0] + "-" + a.FullName.Slug();


            Routes.GenreFilter = FilterPrefix.Genre + filter[1];
            Routes.PriceFilter = FilterPrefix.Price + filter[2];
        }

        //clears appended filters on slug (pulls from route dictionary)
        public void ClearFilters() => Routes.ClearFilters();

        //filterbys
        string d = BookGridDTO.DefaultFilter;
        public bool FilterByAuthor => Routes.AuthorFilter != d;
        public bool FilterByGenre => Routes.GenreFilter != d;
        public bool FilterByPrice => Routes.PriceFilter != d;


        //sorts
        public bool SortByGenre => Routes.SortField.EqualsNoCase(nameof(Genre));
        public bool SortByPrice => Routes.SortField.EqualsNoCase(nameof(Book.Price));

    }
}
