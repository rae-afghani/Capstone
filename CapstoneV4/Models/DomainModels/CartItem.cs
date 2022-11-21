using CapstoneV4.Models.DTOs;
using Newtonsoft.Json;

namespace CapstoneV4.Models.DomainModels
{
    public class CartItem
    {
        //stored in session
        //converted to JSON string
        //subtotal is readonly

        public BookDTO Book { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public double Subtotal => Book.Price * Quantity;

    }
}
