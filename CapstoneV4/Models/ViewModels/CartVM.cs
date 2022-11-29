using CapstoneV4.Models.DomainModels;
using CapstoneV4.Models.Grid;

namespace CapstoneV4.Models.ViewModels
{
    public class CartVM
    {



        public IEnumerable<CartItem> List { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }
        public RouteDictionary CoursesGrid { get; set; }



    }
}
