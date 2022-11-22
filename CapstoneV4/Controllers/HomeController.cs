using CapstoneV4.Models;
using CapstoneV4.Models.DataLayer;
using CapstoneV4.Models.DataLayer.Repositories;
using CapstoneV4.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CapstoneV4.Controllers
{
    public class HomeController : Controller
    {

        private Repository<Book> bookData { get; set; }
        public HomeController(CapstoneDB db) => bookData = new Repository<Book>(db);

        public IActionResult Index()
        {
            //get random book
            var randomBook = bookData.Get(new QueryOptions<Book>
            {
                OrderBy = b => Guid.NewGuid()
            });

            return View(randomBook);
        }

        public ContentResult Register()
        {
            return Content("TODO");
        }

    }
}