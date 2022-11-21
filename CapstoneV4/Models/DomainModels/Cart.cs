﻿
//cart stores items in cart per sesion

using CapstoneV4.Models.DataLayer;
using CapstoneV4.Models.DataLayer.Repositories;
using CapstoneV4.Models.DTOs;
using CapstoneV4.Models.ExtensionMethods;
using System;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CapstoneV4.Models.DomainModels
{
    public class Cart
    {

        private const string CartKey = "usercart";
        private const string CountKey = "usercount";

        private List<CartItem> itemsCart { get; set; }
        private List<CartDTO> storedCart { get; set; }

        private ISession session { get; set; }
        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }

        public Cart(HttpContext ctx)
        {
            session = ctx.Session;
            requestCookies = ctx.Request.Cookies;
            responseCookies = ctx.Response.Cookies;
        }

        public void Load(Repository<Book> data)
        {
            itemsCart = session.GetObj<List<CartItem>>(CartKey);
            if (itemsCart == null)
            {
                itemsCart = new List<CartItem>();
                storedCart = requestCookies.GetCookieObj<List<CartDTO>>(CountKey);
            }
            if(storedCart?.Count > itemsCart?.Count)
            {
                foreach(CartDTO stored in storedCart)
                {
                    var book = data.Get(new QueryOptions<Book> {
                        Includes = "BookAuthors.Author, Genre",
                        Where = b => b.BookId == stored.BookId
                    });

                    if (book != null)
                    {
                        var dto = new BookDTO();
                        dto.Load(book);

                        CartItem item = new CartItem
                        {
                            Book = dto,
                            Quantity = stored.Quantity
                        };

                        itemsCart.Add(item);
                    }
                }
                Save();
            }
        }  

        public double Subtotal => itemsCart.Sum(i => i.Subtotal);
        public int? Count => session.GetInt32(CountKey) ?? requestCookies.GetCookieInt32(CountKey);
        public IEnumerable<CartItem> List => itemsCart;


        //method that returns cart items by the product id
        public CartItem GetByID(int id) => itemsCart.FirstOrDefault(c => c.Book.BookId == id);

        //add items to cart
        //check if exists, if null then add to cart
        public void Add(CartItem item)
        {
            var inCartTest = GetByID(item.Book.BookId);
            if (inCartTest == null)
                itemsCart.Add(item);
            else
                inCartTest.Quantity += 1;
        }

        //allows for cart/quantity value changes by user
        public void Edit(CartItem item)
        {
            var inCartTest = GetByID(item.Book.BookId);
            if (inCartTest != null)
                inCartTest.Quantity = item.Quantity;
        }

        //creating remove method
        public void Remove(CartItem item) => itemsCart.Remove(item);
        public void Clear() => itemsCart.Clear();

        //saves and updates cart to session
        //if cart is empty, removes cart/itemCount (to clear cart icon)
        //intellisense is really cool
        public void Save()
        {
            if (itemsCart.Count == 0)
            {
                session.Remove(CartKey);
                session.Remove(CountKey);

                responseCookies.Delete(CartKey);
                responseCookies.Delete(CountKey);
            }
            else
            {
                session.SetObj<List<CartItem>>(CartKey, itemsCart);
                session.SetInt32(CountKey, itemsCart.Count);
                responseCookies.SetCookieObj<List<CartDTO>>(CartKey, itemsCart.ToDTO());
                responseCookies.SetCookieInt32(CountKey, itemsCart.Count);
            }
        }


    }
}
