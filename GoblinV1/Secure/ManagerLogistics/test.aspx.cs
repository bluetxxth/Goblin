//using GoblinV1.Logic;
//using GoblinV1.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity.Validation;
//using System.Linq;
//using System.Runtime.Remoting.Contexts;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace GoblinV1.UserPages
//{
//    public partial class CreateUser : System.Web.UI.Page
//    {
//        //instantiate store engine to get cart items
//        ShoppingCartEngine cartEngine = new ShoppingCartEngine();
//        private List<CartItem> m_items;
//        private OrderItem m_orderItem;
//        private int m_lastOrderId;
//        private double m_orderTotal;
//        private int m_orderQuantity;
//        private EntityMappingContext ctx = new EntityMappingContext();

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            //get items from cart item list. Only Id comes from session the rest 
//            m_items = cartEngine.GetCartItems();

//        }


//        /// <summary>
//        /// Provides behavior for submit button
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        protected void btnSubmit_Click(object sender, EventArgs e)
//        {

//            //extractCartItems();
//            using (var context = new EntityMappingContext())
//            {

//                //initialize type to avoid nulle refference

//                //CreateAddress
//                Address billingAddress = new Address()
//                {

//                    //Address part
//                    StreetName = txtStreetName.Text,
//                    StreetNo = txtStreetNo.Text,
//                    City = txtCity.Text,
//                    Country = txtCountry.Text,
//                    ZipCode = txtZipCode.Text,

//                };

//                //Create customer
//                Customer customer = new Customer()
//                {

//                    FirstName = txtFirstName.Text,
//                    MiddleName = txtMiddleName.Text,
//                    LastName = txtLastName.Text,
//                    Phone = txtTelephone.Text,
//                    Email = txtEmail.Text,

//                    BillingAddress = billingAddress

//                };


//                //add delivery address
//                Address deliveryAddress = new Address()
//                {
//                    //Address part
//                    StreetName = txtStreetName.Text,
//                    StreetNo = txtStreetNo.Text,
//                    City = txtCity.Text,
//                    Country = txtCountry.Text,
//                    ZipCode = txtZipCode.Text,
//                };


//                //Shippment
//                Shippment shipment = new Shippment()
//                {
//                    CreatedOn = DateTime.Now,
//                    State = "Not shipped",

//                    DeliveryAddress = deliveryAddress
//                };

//                //Session["Error"] = m_items;
//                //Response.Redirect("/UserPages/ErrorPage.aspx");

//                //fill order items - from the c
//                //get just the product id and the quantity. The rest I search for
//                for (int i = 0; i < m_items.Count; i++)
//                {
//                    m_orderItem = new OrderItem()
//                    {

//                        // OrderId = order.OrderId,
//                        ProductId = m_items[i].ProductId,
//                        Quantity = m_items[i].Quantity,
//                        Price = m_items[i].Product.UnitPrice,
//                        ItemName = m_items[i].Product.ProductName,
//                        Specs = m_items[i].Product.Specifications,

//                    };

//                    m_orderQuantity = m_items[i].Quantity;
//                    try
//                    {
//                        // Add OrderDetail to DB.
//                        ctx.OrderItems.Add(m_orderItem);
//                        ctx.SaveChanges();
//                    }
//                    catch (Exception ex)
//                    {
//                        Session["Error"] = ex;
//                        Response.Redirect("ErrorPage.aspx");

//                    }
//                }

//                //create order
//                Order order = new Order()
//                {
//                    Created = DateTime.Now.ToString(),
//                    Qty = m_orderQuantity,
//                    //calculate the pr
//                    Total = ((m_orderItem.Price * m_orderQuantity)),
//                    Address = billingAddress,
//                };

//                //Generate invoice
//                Invoice invoice = new Invoice()
//                {

//                    SubTotal = m_orderItem.Price,
//                    Tax = 0.25,
//                    Total = (m_orderItem.Price * (0.25)) + m_orderItem.Price,
//                    BillingAddress = billingAddress,

//                };


//                try
//                {
//                    ctx.Customers.Add(customer);
//                    ctx.Orders.Add(order);
//                    ctx.Invoices.Add(invoice);
//                    ctx.Shipments.Add(shipment);
//                    ctx.SaveChanges();
//                    m_lastOrderId = order.OrderId;
//                    Session["lastId"] = m_lastOrderId;


//                    //Activate validation 
//                    ctx.Configuration.ValidateOnSaveEnabled = true;

//                }
//                catch (DbEntityValidationException ex)
//                {

//                    //Session["Error"] = ex;

//                    //Response.Redirect("ErrorPage.aspx");

//                    var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);

//                    //join the list to a stingle string
//                    var fullErrorMessage = string.Join("; ", errorMessages);

//                    //combine the original exception message with the new one

//                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
//                    Session["ValidationError"] = fullErrorMessage;


//                    Response.Redirect("ErrorPage.aspx");

//                    //Throw a new DBEntityValidationException with the imrpoved exception message
//                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

//                }

//                Response.Redirect("OrderConfirmation.aspx");

//            }
//        }
//    }
//}
