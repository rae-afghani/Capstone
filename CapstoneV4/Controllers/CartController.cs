using CapstoneV4.Models.DataLayer;
using CapstoneV4.Models.DataLayer.Repositories;
using CapstoneV4.Models.DomainModels;
using CapstoneV4.Models.DTOs;
using CapstoneV4.Models.Grid;
using CapstoneV4.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneV4.Controllers
{
    public class CartController : Controller
    {
        private Repository<Courses> CartData { get; set; }
        public CartController(CapstoneDB db) => CartData = new Repository<Courses>(db);
        private Cart GetCart()
        {
            var cart = new Cart(HttpContext);
            cart.Load(CartData);
            return cart;
        }


        public IActionResult Index()
        {
            Cart cart = GetCart();
            var builder = new CoursesGridBuilder(HttpContext.Session);
            var vm = new CartVM
            {
                List = cart.List,
                Subtotal = cart.Subtotal,
                CoursesGrid = builder.CurrentRoute

            };

            return View(vm);
        }


        [HttpPost]
        public RedirectToActionResult Add(int id)
        {
            var course = CartData.Get(new QueryOptions<Courses>
            {
                Includes = "CourseProgram.Program, Topic",
                Where = c => c.CourseID == id
            });

            if (course == null)
            {
                TempData["message"] = "Unable to add book to cart";

            }
            else
            {
                var dto = new CoursesDTO();
                dto.Load(course);
                CartItem item = new CartItem
                {
                    Course = dto,
                    Quantity = 1 //default

                };

                Cart cart = GetCart();
                cart.Add(item);
                cart.Save();

                TempData["message"] = $"{item.Course.CourseName} was added to cart!";
            }

            var builder = new CoursesGridBuilder(HttpContext.Session);
            return RedirectToAction("List", "Course", builder.CurrentRoute);


        }




        [HttpPost]
        public RedirectToActionResult Remove(int id)
        {
            Cart cart = GetCart();
            CartItem item = cart.GetByID(id);
            cart.Remove(item);
            cart.Save();

            TempData["message"] = $"{item.Course.CourseName} was removed from your cart!";
            return RedirectToAction("Index");
        }


        [HttpPost]
        public RedirectToActionResult Clear()
        {
            Cart cart = GetCart();
            cart.Clear();
            cart.Save();

            TempData["message"] = "Cart has been emptied";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Cart cart = GetCart();
            CartItem item = cart.GetByID(id);

            if (item == null)
            {
                TempData["message"] = "Unable to locate item";
                return RedirectToAction("Index");

            }
            else
            {
                return View(item);
            }
        }

        [HttpPost]
        public RedirectToActionResult Edit(CartItem item)
        {
            Cart cart = GetCart();
            cart.Edit(item);
            cart.Save();

            TempData["message"] = $"{item.Course.CourseName} has been updated";
            return RedirectToAction("Index");
        }


    }
}
