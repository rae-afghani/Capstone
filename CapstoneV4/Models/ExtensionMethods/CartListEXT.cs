using CapstoneV4.Models.DomainModels;
using CapstoneV4.Models.DTOs;

namespace CapstoneV4.Models.ExtensionMethods
{
    public static class CartListEXT
    {
        public static List<CartDTO> ToDTO(this List<CartItem> cart) => cart.Select(c => new CartDTO
        {
            BookId = c.Book.BookId,
            Quantity = c.Quantity

        }).ToList();
    }
}
