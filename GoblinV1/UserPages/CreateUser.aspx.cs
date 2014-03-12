using GoblinV1.Logic;
using GoblinV1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoblinV1.UserPages
{
    public partial class CreateUser : System.Web.UI.Page
    {

        private List<CartItem> m_items;
        private OrderItem m_orderItem;
        private int m_lastOrderId;

        private EntityMappingContext ctx = new EntityMappingContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CartItems"] != null)
            {

                m_items = (List<CartItem>)Session["CartItems"];



            }
            else
            {
                Session["Error"] = "No session passed";

                Response.Redirect("ErrorPage.aspx");
            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            //extractCartItems();

            using (var context = new EntityMappingContext())
            {

                //initialize type to avoid nulle refference

                //CreateAddress
                Address billingAddress = new Address()
                {

                    //Address part
                    StreetName = txtStreetName.Text,
                    StreetNo = Convert.ToInt32(txtStreetNo.Text),
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    ZipCode = Convert.ToInt32(txtZipCode.Text),

                };

                //Create customer
                Customer customer = new Customer()
                {

                    FirstName = txtFirstName.Text,
                    MiddleName = txtMiddleName.Text,
                    LastName = txtLastName.Text,
                    Phone = Convert.ToInt32(txtTelephone.Text),
                    Email = txtEmail.Text,

                    BillingAddress = billingAddress

                };


                //add delivery address
                Address deliveryAddress = new Address()
                {
                    //Address part
                    StreetName = txtStreetName.Text,
                    StreetNo = Convert.ToInt32(txtStreetNo.Text),
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    ZipCode = Convert.ToInt32(txtZipCode.Text),
                };


                //Shippment
                Shippment shipment = new Shippment()
                {
                    CreatedOn = DateTime.Now,
                    State = "Not shipped",


                    DeliveryAddress = deliveryAddress
                };

                //create order
                Order order = new Order()
                {
                    Created = DateTime.Now.ToString(),
                    Address = billingAddress,
                };


                //Session["Error"] = m_items;
                //Response.Redirect("/UserPages/ErrorPage.aspx");



                //fill order items
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

                //Generate invoice
                Invoice invoice = new Invoice()
                {

                    SubTotal = m_orderItem.Price,
                    Tax = 0.25,
                    Total = (m_orderItem.Price * (0.25)) + m_orderItem.Price,

                    BillingAddress = billingAddress,


                };


                try
                {
                    ctx.Customers.Add(customer);
                    ctx.Orders.Add(order);
                    ctx.Invoices.Add(invoice);
                    ctx.Shipments.Add(shipment);
                    ctx.SaveChanges();

                    m_lastOrderId = order.OrderId;

                    Session["lastId"] = m_lastOrderId;


                    //Activate validation 
                    ctx.Configuration.ValidateOnSaveEnabled = true;

                }
                catch (DbEntityValidationException ex)
                {

                    Session["Error"] = ex;

                    Response.Redirect("ErrorPage.aspx");

                    var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);

                    //join the list to a stingle string
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    //combine the original exception message with the new one

                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    Session["Error"] = fullErrorMessage;

                    Response.Redirect("ErrorPage.aspx");

                    //Throw a new DBEntityValidationException with the imrpoved exception message
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

                }
                finally
                {
                    Response.Redirect("OrderConfirmation.aspx");
                }
            }
        }
    }
}
