using CapstoneV4.Models.DataLayer;
using CapstoneV4.Models.DataLayer.Repositories;
using CapstoneV4.Models.DataLayer.SeedData;
using CapstoneV4.Models.DomainModels;
using CapstoneV4.Models.DTOs;
using CapstoneV4.Models.ExtensionMethods;
using CapstoneV4.Models.Grid;
using CapstoneV4.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneV4.Controllers
{
    public class AuthorController : Controller
    {
        private Repository<Author> authorData { get; set; }
        public AuthorController(CapstoneDB db) => authorData = new Repository<Author>(db);

        public IActionResult Index() => RedirectToAction("List");
        
        //sorting and paging defined in program.cs
        public ViewResult List (GridDTO value)
        {
            //pulls grid builder and stores slugs in session
            string defaultSort = nameof(Author.LastName);
            var builder = new GridBuilder(HttpContext.Session, value,defaultSort);
            builder.SaveRouteEvent();

            //queries authors + order by
            var options = new QueryOptions<Author>
            {
                Includes = "BookAuthor.Book",
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection
            };

            if (builder.CurrentRoute.SortField.EqualsNoCase(defaultSort))
                options.OrderBy = a => a.LastName;
            else
                options.OrderBy = a => a.FirstName;

            var viewModel = new AuthorListVM
            {
                Authors = authorData.List(options),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetPageAmt(authorData.Count)
            };
            return View(viewModel);
        }

       
    }
}
