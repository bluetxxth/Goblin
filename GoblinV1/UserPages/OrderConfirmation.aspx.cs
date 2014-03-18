using GoblinV1.Logic;
using GoblinV1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoblinV1.UserPages
{
    public partial class OrderConfirmation : System.Web.UI.Page
    {

        private int m_lastOrderId;

        private EntityMappingContext ctx = new EntityMappingContext();

        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session["lastId"] != null)
            {
                m_lastOrderId = Convert.ToInt32(Session["lastId"]);
            }

            else
            {
                if ((Session["Error"] != null))
                {

                    Response.Redirect("ErrorPage.aspx");
                }
            }

            txtOrderConfirmation.Text = " here is supposed to come the actual confirmation (all the order data) pulled from the DB Submit Order?";

        }


        public void getOrderId()
        {

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

           
         var orderId = ctx.Orders.OrderByDescending(myorder => myorder.OrderId).FirstOrDefault();

         OrderEngine orderEngine = new OrderEngine();

        

            //Change the status or the order
            var order = (from myorder in ctx.Orders
                         where myorder.OrderId == m_lastOrderId// get the corresponding order
                         select myorder).First();  // this will fetch the record.

            order.Submitted = DateTime.Now.ToString() ;
            ctx.SaveChanges();

            try
            {
                ctx.OrderStatuses.Add(orderStatus);
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
                Response.Redirect("ErrorPage.aspx");

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            finally
            {
                Response.Redirect("Products.aspx");
            }
        }
    }
}