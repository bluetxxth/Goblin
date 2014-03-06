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

        EntityMappingContext ctx = new EntityMappingContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CartItems"] != null)
            {

                m_items = (List<CartItem>)Session["CartItems"];
            }
            else
            {
                Session["Error"] = "No session passed";

                Response.Redirect("/UserPages/ErrorPage.aspx");
            }
        }


        /// <summary>
        /// Extract Cart items
        /// </summary>
        public void extractCartItems()
        {
            List<int> productIdList = new List<int>();

            //get all the ids and put them on a list
            using (var ctx = new EntityMappingContext())
            {

                //ctx.Orders.Create();

                //Order order = ctx.Orders.Create();




                Order order = new Order()
                {
                
                };

                //order item information
                for (int i = 0; i < m_items.Count; i++)
                {
                    OrderItem orderItem = new OrderItem()
                    {
                      OrderId = order.OrderId,
                      ProductId = m_items[i].ProductId,
                      Quantity = m_items[i].Quantity,
                      Price = m_items[i].Product.UnitPrice,
                    
                       
                    };

                }

                //Session["Error"] = order.Description;
                //Response.Redirect("/UserPages/ErrorPage.aspx");

                try
                {
                    ctx.Orders.Add(order);
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

                    Session["Error"] = fullErrorMessage;

                    Response.Redirect("/UserPages/ErrorPage.aspx");

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }

            }

            //foreach(int productId  in productIdList)
            //{



            //}

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


                //Change the order status
                OrderStatus orderStatus = new OrderStatus()
                {
                    Status = "Submitted",
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
                    State = "Not shipped",
                    DeliveryAddress = deliveryAddress
                };


                Order order = new Order()
                {
                    Address = billingAddress,
                    Created = DateTime.Now,

                    Description = m_items[1].Product.Specifications,
                    Price = m_items[1].Product.UnitPrice,


                };

               

                //fill order items
                for (int i = 0; i < m_items.Count; i++)
                {
                    OrderItem orderItem = new OrderItem()
                    {
                        OrderId = order.OrderId,
                        ProductId = m_items[i].ProductId,
                        Quantity = m_items[i].Quantity,
                        Price = m_items[i].Product.UnitPrice,

                    };
                
                }

                try
                {
                    ctx.Customers.Add(customer);
                    ctx.SaveChanges();

                    //Activate validation 
                    ctx.Configuration.ValidateOnSaveEnabled = true;

                }
                catch (DbEntityValidationException ex)
                {
                    var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);

                    //join the list to a stingle string
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    //combine the original exception message with the new one

                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    Session["Error"] = fullErrorMessage;

                    Response.Redirect("/UserPages/ErrorPage.aspx");

                    //Throw a new DBEntityValidationException with the imrpoved exception message
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

                }
                finally
                {
                    Response.Redirect("/UserPages/OrderConfirmation.aspx");
                }

            }

        }
    }
}