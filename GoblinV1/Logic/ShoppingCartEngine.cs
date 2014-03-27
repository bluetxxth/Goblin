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
        public const string CartSessionKey = "CartId"; //cartID from session cookie
        private bool m_instock = false;
        public int MyStock { get; set; }
        public int MyQuantity { get; set; }
        public int ProductID { get; set; }
        public string ShoppingCartId { get; set; }


        /// <summary>
        /// Adds items to shoppint cart
        /// </summary>
        /// <param name="id"></param>
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
                    HttpContext.Current.Session["StockError"] = "Not in stock when creating new";
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
                    HttpContext.Current.Session["StockError"] = "Not in stock when adding to existing";
                    HttpContext.Current.Response.Redirect("ErrorPage.aspx");
                }

            }
            //remove from inventory
            DiminishInventory();
            ctx.SaveChanges();
        }


        /// <summary>
        /// Disposes the context
        /// </summary>
        public void Dispose()
        {
            if (ctx != null)
            {
                ctx.Dispose();
                ctx = null;
            }
        }

        /// <summary>
        /// Resets the items in the cart  @TODO needs to be reviewed
        /// </summary>
        public void ZeroCart()
        {
            HttpContext.Current.Session[CartSessionKey] = null;

        }

        /// <summary>
        /// Get cart id
        /// </summary>
        /// <returns></returns>
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
        /// Get the cart
        /// </summary>
        /// <param name="context"></param>
        /// <returns>the corresponding cart</returns>
        public ShoppingCartEngine GetCart(HttpContext context)
        {

            //provide this syntax to ensure correct IDisposable objects
            using (var cart = new ShoppingCartEngine())
            {
                //get cart id
                cart.ShoppingCartId = cart.GetCartId();

                //return the cart
                return cart;
            }
        }


        /// <summary>
        /// Iterate through all the rows within the shopping cart list and  remove it if marked for removal
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="CartItemUpdates"></param>
        public void UpdateShoppingCartDatabase(String cartId, List<ShoppingCartUpdates> CartItemUpdates)
        {
            using (var db = new Models.EntityMappingContext())
            {
                try
                {
                    //count
                    int CartItemCount = CartItemUpdates.Count();

                    //get the cart items
                    List<CartItem> cartItemList = GetCartItems();
                    

                    //traversse the cart items in the cart item list
                    foreach (var cartItem in cartItemList)
                    {
                        // Iterate through all rows within shopping cart list
                        for (int i = 0; i < cartItemList.Count; i++)
                        {
                            //check if the product id matches the cart's update product id
                            if (cartItem.Product.ProductID == CartItemUpdates[i].ProductId)
                            {
                                //if the quantity is less than 1 or if it is marked for removal
                                if (CartItemUpdates[i].PurchaseQuantity < 1 || CartItemUpdates[i].RemoveItem == true)
                                {
                                    RemoveItem(cartId, cartItem.ProductId);
                                }
                                else
                                {
                                    //update the items's purhcase quantity
                                    UpdateItem(cartId, cartItem.ProductId, CartItemUpdates[i].PurchaseQuantity);
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Database - " + exp.Message.ToString(), exp);
                }
            }
        }


        /// <summary>
        /// Remove the item
        /// </summary>
        /// <param name="removeCartID"></param>
        /// <param name="removeProductID"></param>
        public void RemoveItem(string removeCartID, int removeProductID)
        {

            //get the database
            using (var ctx = new Models.EntityMappingContext())
            {
                try
                {
                    //get item
                    var myItem = (from myCartItem in ctx.CartItems where myCartItem.CartId == removeCartID && myCartItem.Product.ProductID == removeProductID select myCartItem).FirstOrDefault();
                    
                    if (myItem != null)
                    {
                        // Remove Item.
                        ctx.CartItems.Remove(myItem);
                        ctx.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Remove Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }


        /// <summary>
        /// Updates the cart items
        /// </summary>
        /// <param name="updateCartID"></param>
        /// <param name="updateProductID"></param>
        /// <param name="quantity"></param>
        public void UpdateItem(string updateCartID, int updateProductID, int quantity)
        {

            //startup context
            using (var ctx = new Models.EntityMappingContext())
            {
                try
                {
                    //get the item
                    var myItem = (from myCartItem in ctx.CartItems where myCartItem.CartId == updateCartID && myCartItem.Product.ProductID == updateProductID select myCartItem).FirstOrDefault();
                    if (myItem != null)
                    {
                        //set the quantity
                        myItem.Quantity = quantity;
                        ctx.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        /// <summary>
        /// Empties shopping cart
        /// </summary>
        public void EmptyCart()
        {
            ShoppingCartId = GetCartId();
            var cartItems = ctx.CartItems.Where(
                c => c.CartId == ShoppingCartId);
            foreach (var cartItem in cartItems)
            {
                ctx.CartItems.Remove(cartItem);
            }
            // Save changes.             
            ctx.SaveChanges();
        }


        /// <summary>
        /// Counter for the shopping cart
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            ShoppingCartId = GetCartId();

            // Get the count of each item in the cart and sum them up          
            int? count = (from cartItems in ctx.CartItems
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Quantity).Sum();
            // Return 0 if all entries are null         
            return count ?? 0;
        }


        /// <summary>
        /// Structure with options for for shopping cart Update
        /// </summary>
        public struct ShoppingCartUpdates
        {
            public int ProductId;
            public int PurchaseQuantity;
            public bool RemoveItem;
        }

        /// <summary>
        /// Use existing cart id to find  shopping cart of the user
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="userName"></param>
        public void MigrateCart(string cartId, string userName)
        {
            //get the cart id with link to sql
            var shoppingCart = ctx.CartItems.Where(c => c.CartId == cartId);
            //traverse te list of CarItems in the shopping cart
            foreach (CartItem item in shoppingCart)
            {
                //assign the user name to the cart id
                item.CartId = userName;
            }
            //save the user name in a session
            HttpContext.Current.Session[CartSessionKey] = userName;

            //save changes to db
            ctx.SaveChanges();
        }
    }
}