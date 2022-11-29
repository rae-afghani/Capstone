using CapstoneV4.Models.DTOs;
using Newtonsoft.Json;

namespace CapstoneV4.Models.DomainModels
{
    public class CartItem
    {
        //stored in session
        //converted to JSON string
        //subtotal is readonly

        public CoursesDTO Course { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public double Subtotal => Course.Tuition * Quantity;


        //accounting for tax
        public double Total => Subtotal * 1.0625;

    }
}
