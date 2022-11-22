using CapstoneV4.Models.DataLayer;
using CapstoneV4.Models.DataLayer.Repositories;
using CapstoneV4.Models.DomainModels;
using CapstoneV4.Models.DTOs;
using CapstoneV4.Models.ExtensionMethods;
using CapstoneV4.Models.Grid;
using CapstoneV4.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneV4.Controllers
{
    public class BookController : Controller
    {
        //pulling for CRUD operations
        private StoreUoW Data { get; set; }
        public BookController(CapstoneDB db) => Data = new StoreUoW(db);


        public IActionResult Index() => RedirectToAction("List");

        //paging, sorting, filtering defined in program.cs
        public ViewResult List(BookGridDTO values)
        {
            var builder = new BookGridBuilder(HttpContext.Session, values, defaultSortFilter: nameof(Book.Title));

            var options = new BookQueryOptions
            {
                Includes = "BookAuthor.Author, Genre",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
            };

            //calling SOrtFilter() metho
            options.SortFilter(builder);


            //view model, page size and dropdowns
            var vm = new BookListVM
            {
                Books = Data.Books.List(options),
                Authors = Data.Authors.List(new QueryOptions<Author> { OrderBy = a => a.FirstName }),
                Genres = Data.Genres.List(new QueryOptions<Genre> { OrderBy = g => g.Name }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetPageAmt(Data.Books.Count)

            };
            return View(vm);

        }

        public ViewResult Details(int id)
        {
            var book = Data.Books.Get(new QueryOptions<Book>
            {
                Includes = "BookAuthor.Author,Genre",
                Where = b => b.BookId == id
            });
            return View(book);
        }

        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            //get current route segments from session
            var builder = new BookGridBuilder(HttpContext.Session);

            //clear update filter + update segments/slugs
            if (clear == true)
            {
                builder.ClearFilters();            }

            else
            {
                var author = Data.Authors.Get(filter[0].ToInt());
                builder.CurrentRoute.PageNumber = 1;
                builder.ReloadRoutes(filter, author);
            }

            builder.SaveRouteEvent();
            return RedirectToAction("List", builder.CurrentRoute);


        }

        [HttpPost]
        public RedirectToActionResult PageSize(int pagesize)
        {
            var builder = new BookGridBuilder(HttpContext.Session);

            builder.CurrentRoute.PageSize = pagesize;
            builder.SaveRouteEvent();

            return RedirectToAction("List", builder.CurrentRoute);
        }


    }
}
