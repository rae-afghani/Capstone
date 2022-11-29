using CapstoneV4.Models.DataLayer;
using CapstoneV4.Models.DataLayer.Repositories;
using CapstoneV4.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneV4.Controllers
{
    public class HomeController : Controller
    {

        private Repository<Courses> courseData { get; set; }
        public HomeController(CapstoneDB db) => courseData = new Repository<Courses>(db);

        public IActionResult Index()
        {
            return View();
        }

        public ContentResult Register()
        {
            return Content("TODO");
        }

    }
}