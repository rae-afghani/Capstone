using CapstoneV4.Models.DataLayer;
using CapstoneV4.Models.DataLayer.Repositories;
using CapstoneV4.Models.DTOs;
using CapstoneV4.Models.ExtensionMethods;
using CapstoneV4.Models.Grid;
using CapstoneV4.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneV4.Controllers
{
    public class ProgramsController : Controller
    {
        private Repository<Models.DomainModels.Program> programData { get; set; }
        public ProgramsController(CapstoneDB db) => programData = new Repository<Models.DomainModels.Program>(db);

        public IActionResult Index() => RedirectToAction("List");

        //sorting and paging defined in program.cs
        public ViewResult List(GridDTO value)
        {
            //pulls grid builder and stores slugs in session
            string defaultSort = nameof(Models.DomainModels.Program.ProgramDescription);
            var builder = new GridBuilder(HttpContext.Session, value, defaultSort);
            builder.SaveRouteEvent();

            //queries authors + order by
            var options = new QueryOptions<Models.DomainModels.Program>
            {
                Includes = "CourseProgram.Course",
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection
            };

            if (builder.CurrentRoute.SortField.EqualsNoCase(defaultSort))
                options.OrderBy = a => a.ProgramDescription;
            else
                options.OrderBy = a => a.ProgramType;

            var viewModel = new ProgramListVM
            {
                Programs = programData.List(options),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetPageAmt(programData.Count)
            };
            return View(viewModel);
        }


    }
}
