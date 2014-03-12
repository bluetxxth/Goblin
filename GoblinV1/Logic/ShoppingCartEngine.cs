using GoblinV1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;

namespace GoblinV1.Logic
{
    public class ShoppingCartEngine : IDisposable
    {


        private EntityMappingContext ctx = new EntityMappingContext();

        public const string CartSessionKey = "CartId";

        private bool m_instock = false;

        public int MyStock { get; set; }

        public int MyQuantity { get; set; }
        public int ProductID { get; set; }
        public string ShoppingCartId { get; set; }

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
                    CartItemId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    CartId = ShoppingCartId,
                    Product = ctx.Products.SingleOrDefault(
                    product => product.ProductID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                //Change the status or the order
                var pr = (from myproduct in ctx.Products
                               where myproduct.ProductID == ProductID // get the corresponding order
                               select myproduct).FirstOrDefault();  // this will fetch the record.

                MyQuantity = Convert.ToInt32(cartItem.Quantity);
                MyStock = Convert.ToInt32(pr.Stock);

                //HttpContext.Current.Session["Error"] = MyStock;
                //HttpContext.Current.Response.Redirect("ErrorPage.aspx");

                if ((MyStock) > 0)
                {

                    ctx.CartItems.Add(cartItem);
 
                }
                else
                {
                    HttpContext.Current.Session["Error"] = "Not in stock when creating new";
                    HttpContext.Current.Response.Redirect("ErrorPage.aspx");

                }
            }
            else
            {

                //Change the status or the order
                var pr = (from myproduct in ctx.Products
                          where myproduct.ProductID == ProductID // get the corresponding order
                          select myproduct).FirstOrDefault();  // this will fetch the record.

                MyStock = Convert.ToInt32(pr.Stock);

                //HttpContext.Current.Session["Error"] = MyStock;
                //HttpContext.Current.Response.Redirect("ErrorPage.aspx");

                //check stock
                if ((MyStock) > 0)
                {
                    // If the item does exist in the cart,                  
                    // then add one to the quantity.                 
                    cartItem.Quantity++;
            
                }
                else
                {
                    HttpContext.Current.Session["Error"] = "Not in stock when adding to existing";
                    HttpContext.Current.Response.Redirect("ErrorPage.aspx");
                }

            }

            DiminishInventory();
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

        /// <summary>
        /// Get totals
        /// </summary>
        /// <returns></returns>
        public decimal GetTotal()
        {
            ShoppingCartId = GetCartId();
            decimal? total = decimal.Zero;
            total = (decimal?)(from cartItems in ctx.CartItems
                               where cartItems.CartId == ShoppingCartId
                               select (int?)cartItems.Quantity *
                               cartItems.Product.UnitPrice).Sum();

            //HttpContext.Current.Session["Error"] = "cartID: " + total;
            //HttpContext.Current.Response.Redirect("/UserPages/ErrorPage.aspx");

            return total ?? decimal.Zero;
        }

        /// <summary>
        /// Get price per unit
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// Get item quantity
        /// </summary>
        /// <returns></returns>
        public int GetQuantity()
        {
            ShoppingCartId = GetCartId();
 
             var quantity = (from cartItems in ctx.CartItems
                                where cartItems.Product.ProductID == ProductID
                             select (int?)cartItems.Quantity).FirstOrDefault();

             int myQuantity = Convert.ToInt32(quantity);

             //HttpContext.Current.Session["Error"] = ShoppingCartId;
             //HttpContext.Current.Response.Redirect("ErrorPage.aspx");

             return myQuantity;
        }



        /// <summary>
        /// Diminish inventory availability for a given product
        /// </summary>
        public void DiminishInventory()
        {
            //HttpContext.Current.Session["Error"] = ProductID;
            //HttpContext.Current.Response.Redirect("ErrorPage.aspx");

            //Change the status or the order
            var product = (from myproduct in ctx.Products
                         where myproduct.ProductID == ProductID // get the corresponding order
                         select myproduct).FirstOrDefault();  // this will fetch the record.

            int mystock = Convert.ToInt32(product.Stock);

             product.Stock --;


            try
            {
                ctx.SaveChanges();
                //validate
                ctx.Configuration.ValidateOnSaveEnabled = true;
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                  .SelectMany(x => x.ValidationErrors)
                  .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                HttpContext.Current.Session["Error"] = fullErrorMessage;
                HttpContext.Current.Response.Redirect("ErrorPage.aspx");

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            finally
            {
                HttpContext.Current.Response.Redirect("ShoppingCart.aspx");
            }
        }


        /// <summary>
        /// Check Inventory
        /// </summary>
        /// <returns></returns>
        public bool GetInventoryAvailability()
        {
            int orderQuantity = GetQuantity();

            // Query the database for the row to be updated. 
            var productStock =
                (from myproduct in ctx.Products
                 where myproduct.ProductID == ProductID
                 select myproduct.Stock).FirstOrDefault();

           int myStock = Convert.ToInt32(productStock);

            if (myStock > orderQuantity)
            {
                m_instock = true;
            }
            else
            {
                m_instock = false;
            }

            return m_instock; 
        }
     

        /// <summary>
        /// Get the products name
        /// </summary>
        /// <returns></returns>
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