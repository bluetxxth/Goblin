using Goblin.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Goblin.BLL
{
  public class ShoppingCartEngine : IDisposable
    {


        private EntityMappingContext ctx = new EntityMappingContext();
        public const string CartSessionKey = "CartId"; //cartID from session cookie
        private bool m_instock = false;

        //instantiate store engine to get cart items
        private List<CartItem> m_items;

        private OrderItem m_orderItem;
        private int m_orderQuantity;
        private int m_lastOrderId;
        private int m_lastOrderConfirmationId;


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

            product.Stock--;


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
            using (var db = new EntityMappingContext())
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
            using (var ctx = new EntityMappingContext())
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
            using (var ctx = new EntityMappingContext())
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
            int? count = 0;

            try
            {
                // Get the count of each item in the cart and sum them up          
                count = (from cartItems in ctx.CartItems
                         where cartItems.CartId == ShoppingCartId
                         select (int?)cartItems.Quantity).Sum();

            }
            catch (EntityCommandExecutionException ex)
            {
                HttpContext.Current.Session["Error"] = ex;

                HttpContext.Current.Response.Redirect("/UserPages/ErrorPage.aspx");
            }
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


        /// <summary>
        /// Create the order
        /// </summary>
        /// <param name="currentUser"></param>
        public void CreateOrder(ApplicationUser currentUser)
        {
            //start by getting the current user
            AdminEngine adminEngine = new AdminEngine();

            //// && System.Web.HttpContext.Current.User.IsInRole("user")

            string user = System.Web.HttpContext.Current.User.Identity.Name;

            //var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            //store.AutoSaveChanges = false;

            //var currentUserId = User.Identity.GetUserId();
            //var manager = new UserManager<ApplicationUser>(store);
            //var currentUser = manager.FindById(User.Identity.GetUserId());

            //currentUser.MyUserInfo = new MyUserInfo();

            //extractCartItems();
            using (var context = new EntityMappingContext())
            {

                //Session["Error"] = m_items;
                //Response.Redirect("/UserPages/ErrorPage.aspx");

                m_items = GetCartItems();

                //fill order items - from the cart
                //get just the product id and the quantity. The rest I search for
                for (int i = 0; i < m_items.Count; i++)
                {
                    m_orderItem = new OrderItem()
                    {
                        // OrderId = order.OrderId,
                        ProductId = m_items[i].ProductId,
                        Quantity = m_items[i].Quantity,
                        Price = m_items[i].Product.UnitPrice,
                        ItemName = m_items[i].Product.ProductName,
                        Specs = m_items[i].Product.Specifications,

                    };

                    m_orderQuantity = m_items[i].Quantity;
                    try
                    {
                        // Add OrderDetail to DB.
                        ctx.OrderItems.Add(m_orderItem);
                        ctx.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        HttpContext.Current.Session["Error"] = ex;
                        HttpContext.Current.Response.Redirect("ErrorPage.aspx");
                    }
                }

                //create order
                Order order = new Order()
                {
                    Created = DateTime.Now.ToString(),
                    Qty = m_orderQuantity,
                    //calculate the pr
                    Total = ((m_orderItem.Price * m_orderQuantity)),
                    //       Address = billingAddress,
                };

                //Generate invoice
                Invoice invoice = new Invoice()
                {

                    SubTotal = m_orderItem.Price,
                    Tax = 0.25,
                    Total = (m_orderItem.Price * (0.25)) + m_orderItem.Quantity,
                    //       BillingAddress = billingAddress,

                };

                //Generate Order Confirmation
                OrderConfirmation orderConfirmation = new OrderConfirmation()
                {

                    CustomerName = currentUser.MyUserInfo.FirstName,
                    CustomerMiddle = currentUser.MyUserInfo.MiddleName,
                    CustomerLast = currentUser.MyUserInfo.LastName,
                    CustomerPhone = currentUser.MyUserInfo.Telephone,
                    CustomerCell = currentUser.MyUserInfo.Cellphone,
                    CustomerEmail = currentUser.MyUserInfo.Email,

                    BillingAddressName = currentUser.BillingAddress.AddressName,
                    BillingAddressNo = currentUser.BillingAddress.AddressNumber,
                    BillingApartment = currentUser.BillingAddress.Apartment,
                    BillingStair = currentUser.BillingAddress.Stair,
                    BillingZipCode = currentUser.BillingAddress.Zipcode,
                    BillingCity = currentUser.BillingAddress.City,
                    BillingCountry = currentUser.BillingAddress.Country,

                    ShippingAddressName = currentUser.ShippingAddress.AddressName,
                    ShippingAddressNo = currentUser.ShippingAddress.AddressNumber,
                    ShippingApartment = currentUser.ShippingAddress.Apartment,
                    ShippingStair = currentUser.ShippingAddress.Stair,
                    ShippingZipCode = currentUser.ShippingAddress.Zipcode,
                    ShippingCity = currentUser.ShippingAddress.City,

                    ////Product Data
                    ProductName = m_orderItem.ItemName,
                    Quantity = order.Qty,
                    ProductSpec = m_orderItem.Specs,
                    ProductPrice = m_orderItem.Price,
                    Subtotal = (order.Total * order.Qty),
                    Total = ((order.Total * order.Qty) * 1.25),

                    //Payment Data - Credit Card
                    CCardName = currentUser.MyUserCCardInfo.CardName,
                    CCardNo = currentUser.MyUserCCardInfo.CardNumber,
                    CCArdExpiryDate = currentUser.MyUserCCardInfo.CardExpiryDate,
                    CCardSecurityCode = currentUser.MyUserCCardInfo.CardSecurityCode,

                };

                //initialize type to avoid nulle refference

                //CreateAddress
                Address billingAddress = new Address()
                {
                    //Address part
                    StreetName = currentUser.BillingAddress.AddressName,
                    StreetNo = currentUser.BillingAddress.AddressNumber,
                    City = currentUser.BillingAddress.City,
                    Country = currentUser.BillingAddress.Country,
                    ZipCode = currentUser.BillingAddress.Zipcode,
                };



                //Create customer
                Customer customer = new Customer()
                {
                    FirstName = currentUser.MyUserInfo.FirstName,
                    MiddleName = currentUser.MyUserInfo.MiddleName,
                    LastName = currentUser.MyUserInfo.LastName,
                    Phone = currentUser.MyUserInfo.Telephone,
                    CellPhone = currentUser.MyUserInfo.Cellphone,
                    Email = currentUser.MyUserInfo.Email

                    //BillingAddress = billingAddress
                };


                //add delivery address
                Address deliveryAddress = new Address()
                {
                    //Address part
                    StreetName = currentUser.ShippingAddress.AddressName,
                    StreetNo = currentUser.ShippingAddress.AddressNumber,
                    City = currentUser.ShippingAddress.City,
                    Country = currentUser.ShippingAddress.Country,
                    ZipCode = currentUser.ShippingAddress.Zipcode,
                };


                //Shippment
                Shippment shipment = new Shippment()
                {

                    State = "Not shipped",

                    AddresName = currentUser.ShippingAddress.AddressName,
                    AddressNo = currentUser.ShippingAddress.AddressNumber,
                    AddresApt = currentUser.ShippingAddress.Apartment,
                    AddresStair = currentUser.ShippingAddress.Stair,
                    Country = currentUser.ShippingAddress.Country,
                    City = currentUser.ShippingAddress.City,
                    ZipCode = currentUser.ShippingAddress.Zipcode,


                };

                try
                {

                    // ctx.OrderStatuses.Add(orderStatus);
                    ctx.Addresses.Add(billingAddress);
                    ctx.Customers.Add(customer);
                    ctx.Orders.Add(order);
                    ctx.Invoices.Add(invoice);
                    ctx.OrderConfirmations.Add(orderConfirmation);
                    ctx.Shipments.Add(shipment);
                    ctx.SaveChanges();


                    m_lastOrderId = order.OrderId;
                    HttpContext.Current.Session["lastId"] = m_lastOrderId;

                    m_lastOrderConfirmationId = orderConfirmation.OrderId;
                    HttpContext.Current.Session["lastOrderConfId"] = m_lastOrderId;


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
                    HttpContext.Current.Response.Redirect("/UserPages/ErrorPage.aspx");

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }

                finally
                {
                    //orderId
                    var orderId = ctx.Orders.OrderByDescending(myorder => myorder.OrderId).FirstOrDefault();

                    OrderEngine orderEngine = new OrderEngine();
                    //Change the status or the order
                    var anorder = (from myorder in ctx.Orders
                                   where myorder.OrderId == m_lastOrderId// get the corresponding order
                                   select myorder).First();  // this will fetch the record.

                    anorder.Submitted = DateTime.Now.ToString();
                    ctx.SaveChanges();

                }

                ////reset the cart for next order
                //// cartEngine.ZeroCart();
                //EmptyCart();
                //HttpContext.Current.Response.Redirect("/UserPages/Products.aspx");

            }//end EntityMappingContext

        }



    }
}
