using GoblinV1.Logic;
using GoblinV1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace GoblinV1.UserPages
{
    public partial class ConfirmOrder : System.Web.UI.Page
    {
        private int m_lastOrderId;
        private EntityMappingContext ctx = new EntityMappingContext();
        private IdentityDbContext idbctxt = new IdentityDbContext();
        private ShoppingCartEngine cartEngine = new ShoppingCartEngine();

        //instantiate store engine to get cart items
        private List<CartItem> m_items;
        private OrderItem m_orderItem;

        private double m_orderTotal;
        private int m_orderQuantity;


        protected void Page_Load(object sender, EventArgs e)
        {

            //get items from cart item list. Only Id comes from session the rest 
            m_items = cartEngine.GetCartItems();

            if (Session["lastId"] != null)
            {
                this.m_lastOrderId = Convert.ToInt32(Session["lastId"]);
            }

            else
            {
                if ((Session["Error"] != null))
                {
                    Response.Redirect("ErrorPage.aspx");
                }
            }

            bindEmployeeDetailsToRepeater();

          
        }

        /// <summary>
        /// Method to bind employee records to repeater control.
        /// </summary>
        void bindEmployeeDetailsToRepeater()
        {
            using (EntityMappingContext context = new EntityMappingContext())
            {
                rptConfirmOrder.DataSource = (from oc in context.OrderConfirmations.ToList()
                                              select oc).Take(1);
                rptConfirmOrder.DataBind();
            }
        }

        /// <summary>
        /// Behavior for submit button - change order status to submitted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //create an order status object in order to set it to submitted
            OrderStatus orderStatus = new OrderStatus()
            {
                Status = "Submitted" + DateTime.Now.ToString()
            };
         
            //start by getting the current user
            AdminEngine adminEngine = new AdminEngine();

            //// && System.Web.HttpContext.Current.User.IsInRole("user")

            string user = System.Web.HttpContext.Current.User.Identity.Name;

            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            store.AutoSaveChanges = false;

            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(store);
            var currentUser = manager.FindById(User.Identity.GetUserId());

            //currentUser.MyUserInfo = new MyUserInfo();

            //extractCartItems();
            using (var context = new EntityMappingContext())
            {

                //initialize type to avoid nulle refference

                ////CreateAddress
                //Address billingAddress = new Address()
                //{
                //    //Address part
                //    StreetName = currentUser.BillingAddress.AddressName,
                //    StreetNo = currentUser.BillingAddress.AddressNumber,
                //    City = currentUser.BillingAddress.City,
                //    Country = currentUser.BillingAddress.Country,
                //    ZipCode = currentUser.BillingAddress.Zipcode,
                //};


                ////Create customer
                //Customer customer = new Customer()
                //{
                //    FirstName = currentUser.MyUserInfo.FirstName,
                //    MiddleName = currentUser.MyUserInfo.MiddleName,
                //    LastName = currentUser.MyUserInfo.LastName,
                //    Phone = currentUser.MyUserInfo.Telephone,
                //    CellPhone = currentUser.MyUserInfo.Cellphone,
                //    Email = currentUser.MyUserInfo.Email
                    
                //    //BillingAddress = billingAddress
                //};


                ////add delivery address
                //Address deliveryAddress = new Address()
                //{
                //    //Address part
                //    StreetName = currentUser.ShippingAddress.AddressName,
                //    StreetNo = currentUser.ShippingAddress.AddressNumber,
                //    City = currentUser.ShippingAddress.City,
                //    Country = currentUser.ShippingAddress.Country,
                //    ZipCode = currentUser.ShippingAddress.Zipcode,
                //};

                ////Shippment
                //Shippment shipment = new Shippment()
                //{
                //    CreatedOn = DateTime.Now,
                //    State = "Not shipped",

                //    DeliveryAddress = deliveryAddress
                //};

                //Session["Error"] = m_items;
                //Response.Redirect("/UserPages/ErrorPage.aspx");

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
                        Session["Error"] = ex;
                        Response.Redirect("ErrorPage.aspx");
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
                    Total = (m_orderItem.Price * (0.25)) + m_orderItem.Price,
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
                    Quantity = m_orderItem.Quantity,
                    ProductSpec = m_orderItem.Specs,
                    ProductPrice = m_orderItem.Price,

                    ////Customer info
                    //CustomerName = customer.FirstName,
                    //CustomerMiddle = customer.MiddleName,
                    //CustomerLast = customer.LastName,
                    //CustomerCell = customer.CellPhone,
                    //CustomerPhone = customer.Phone,

                    ////Billing Address info
                    //BillingAddressName = customer.BillingAddress.StreetName,
                    //BillingAddressNo = customer.BillingAddress.StreetNo,
                    //BillingApartment = customer.BillingAddress.Apartment,
                    //BillingStair = customer.BillingAddress.Stair,
                    //BillingZipCode = customer.BillingAddress.ZipCode,
                    //BillingCountry = customer.BillingAddress.Country,
                    //BillingCity = customer.BillingAddress.City,

                    ////Shipping Address info
                    //ShippingAddressName = customer.ShippingAddress.StreetName,
                    //ShippingAddressNo = customer.ShippingAddress.StreetNo,
                    //ShippingApartment = customer.ShippingAddress.Apartment,
                    //ShippingStair = customer.ShippingAddress.Stair,
                    //ShippingZipCode = customer.ShippingAddress.ZipCode,
                    //ShippingCountry = customer.ShippingAddress.Country,
                    //ShippingCity = customer.ShippingAddress.City,

                    ////Product Data
                    //Quantity = m_orderItem.Quantity,
                    //ProductSpec = m_orderItem.Specs,
                    //ProductPrice = m_orderItem.Price,

                    ////Payment Data - Bank
                    //BankName = currentUser.MyUserBankInfo.BankName,
                    //BankAccount = currentUser.MyUserBankInfo.BankAccountNo,
                    //BankBicNo = currentUser.MyUserBankInfo.BicNo,
                    //BankSwiftCode = currentUser.MyUserBankInfo.BankSwift,

                    //Payment Data - Credit Card
                    CCardName = currentUser.MyUserCCardInfo.CardName,
                    CCardNo = currentUser.MyUserCCardInfo.CardNumber,
                    CCArdExpiryDate = currentUser.MyUserCCardInfo.CardExpiryDate,
                    CCardSecurityCode = currentUser.MyUserCCardInfo.CardSecurityCode,

                };

                try
                {

                    ctx.OrderStatuses.Add(orderStatus);
                    //ctx.Customers.Add(customer);
                    ctx.Orders.Add(order);
                    ctx.Invoices.Add(invoice);
                    //ctx.Shipments.Add(shipment);
                    ctx.OrderConfirmations.Add(orderConfirmation);
                    ctx.SaveChanges();
                    m_lastOrderId = order.OrderId;
                    Session["lastId"] = m_lastOrderId;

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

                    Session["Error"] = fullErrorMessage;
                    Response.Redirect("/UserPages/ErrorPage.aspx");

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

                //reset the cart for next order
               // cartEngine.ZeroCart();
                cartEngine.EmptyCart();
                Response.Redirect("/UserPages/Products.aspx");

            }//end EntityMappingContext


        }

    
    }
}