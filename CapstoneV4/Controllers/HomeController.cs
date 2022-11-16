using CapstoneV4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CapstoneV4.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

    }
}