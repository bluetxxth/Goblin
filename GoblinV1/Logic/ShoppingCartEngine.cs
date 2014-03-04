using GoblinV1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;

namespace GoblinV1.Logic
{
    public class ShoppingCartEngine : IDisposable
    {

        public int ProductID { get; set; }
      
        public string ShoppingCartId { get; set; }

        private EntityMappingContext ctx = new EntityMappingContext();

        public const string CartSessionKey = "CartId";

        public void AddToCart(int id)
        {

            ProductID = id;

            //HttpContext.Current.Session["Error"] = "CartSessionKey: " + ProductID;
            //HttpContext.Current.Response.Redirect("/UserPages/ErrorPage.aspx");

            // Retrieve the product from the database.           
            ShoppingCartId = GetCartId();

            var cartItem = ctx.CartItems.SingleOrDefault(
                cart => cart.CartId == ShoppingCartId
                && cart.ProductId == id);

            if (cartItem == null)
            {

                // Create a new cart item if no cart item exists.                 
                cartItem = new CartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    CartId = ShoppingCartId,
                    Product = ctx.Products.SingleOrDefault(
                     product => product.ProductID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                ctx.CartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.Quantity++;
            }
            ctx.SaveChanges();
        }

        public void Dispose()
        {
            if (ctx != null)
            {
                ctx.Dispose();
                ctx = null;
            }
        }

        public string GetCartId()
        {

            if ((HttpContext.Current.Session[CartSessionKey] == null))
            {
                        // Generate a new random GUID using System.Guid class.     
                        Guid tempCartId = Guid.NewGuid();
                        HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();

                        //HttpContext.Current.Session["Error"] = "cartID: " + tempCartId.ToString();
                        //HttpContext.Current.Response.Redirect("/UserPages/ErrorPage.aspx");
                        
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }


        /// <summary>
        /// Get car items
        /// </summary>
        /// <returns>A list of items</returns>
        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            //HttpContext.Current.Session["Error"] = "cartID: " + ShoppingCartId;
            //HttpContext.Current.Response.Redirect("/UserPages/ErrorPage.aspx");

            return ctx.CartItems.Where(
                cart => cart.CartId == ShoppingCartId).ToList();
        }


        public decimal GetTotal()
        {
            ShoppingCartId = GetCartId();
            // Multiply product price by quantity of that product to get        
            // the current price for each of those products in the cart.  
            // Sum all product price totals to get the cart total.   

            decimal? total = decimal.Zero;
            total = (decimal?)(from cartItems in ctx.CartItems
                               where cartItems.CartId == ShoppingCartId
                               select (int?)cartItems.Quantity *
                               cartItems.Product.UnitPrice).Sum();

            //HttpContext.Current.Session["Error"] = "cartID: " + total;
            //HttpContext.Current.Response.Redirect("/UserPages/ErrorPage.aspx");

            return total ?? decimal.Zero;
        }

        public decimal GetPricePerUnit()
        {
            ShoppingCartId = GetCartId();
            // Multiply product price by quantity of that product to get        
            // the current price for each of those products in the cart.  
            // Sum all product price totals to get the cart total.   

            decimal? total = decimal.Zero;
            total = (decimal?)(from cartItems in ctx.CartItems
                               where cartItems.CartId == ShoppingCartId
                               select (int?)cartItems.Quantity *
                               cartItems.Product.UnitPrice).Sum();

            //HttpContext.Current.Session["Error"] = "cartID: " + total;
            //HttpContext.Current.Response.Redirect("/UserPages/ErrorPage.aspx");

            return total ?? decimal.Zero;
        }

        public string GetName()
        {
            string strProductId = HttpContext.Current.Session["productId"].ToString();

            //HttpContext.Current.Session["Error"] = "productId: " + productId;
            //HttpContext.Current.Response.Redirect("/UserPages/ErrorPage.aspx");

            int intProductId = Convert.ToInt32(strProductId);

            string productName = null;

            var product = ctx.Products.Find(intProductId);

            productName = product.ProductName;

            return productName;
        }
    }
}