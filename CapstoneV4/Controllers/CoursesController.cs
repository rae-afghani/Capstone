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
    public class CoursesController : Controller
    {
        //pulling for CRUD operations
        private StoreUoW Data { get; set; }
        public CoursesController(CapstoneDB db) => Data = new StoreUoW(db);


        public IActionResult Index() => RedirectToAction("List");

        //paging, sorting, filtering defined in program.cs
        public ViewResult List(CourseGridDTO values)
        {
            var builder = new CoursesGridBuilder(HttpContext.Session, values, defaultSortFilter: nameof(Courses.CourseName));

            var options = new CourseQueryOptions
            {
                Includes = "CourseProgram.Program, Topic",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
            };

            //calling SOrtFilter() metho
            options.SortFilter(builder);


            //view model, page size and dropdowns
            var vm = new CourseListVM
            {
                Courses = Data.Courses.List(options),
                Programs = Data.Programs.List(new QueryOptions<Models.DomainModels.Program> { OrderBy = a => a.ProgramType }),
                Topics = Data.Topics.List(new QueryOptions<Topics> { OrderBy = g => g.Name }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetPageAmt(Data.Courses.Count)

            };
            return View(vm);

        }

        public ViewResult Details(int id)
        {
            var course = Data.Courses.Get(new QueryOptions<Courses>
            {
                Includes = "CourseProgram.Program,Topic",
                Where = c => c.CourseID == id
            });
            return View(course);
        }

        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            //get current route segments from session
            var builder = new CoursesGridBuilder(HttpContext.Session);

            //clear update filter + update segments/slugs
            if (clear == true)
            {
                builder.ClearFilters();
            }

            else
            {
                var program = Data.Programs.Get(filter[0].ToInt());
                builder.CurrentRoute.PageNumber = 1;
                builder.ReloadRoutes(filter, program);
            }

            builder.SaveRouteEvent();
            return RedirectToAction("List", builder.CurrentRoute);


        }

        [HttpPost]
        public RedirectToActionResult PageSize(int pagesize)
        {
            var builder = new CoursesGridBuilder(HttpContext.Session);

            builder.CurrentRoute.PageSize = pagesize;
            builder.SaveRouteEvent();

            return RedirectToAction("List", builder.CurrentRoute);
        }


    }
}
