using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoblinV1.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Goblin.BLL;
using Goblin.Model;

namespace Goblin.Secure.Staff
{
    public partial class ProcessOrders : System.Web.UI.Page
    {
        private EntityMappingContext ctx = new EntityMappingContext();
        private OrderEngine orderEngine = new OrderEngine();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Get orders
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrders()
        {

            return orderEngine.GetOrder();
        }

        /// <summary>
        /// Get orders
        /// </summary>
        /// <returns></returns>
        public List<OrderConfirmation> GetOrderConfirmation()
        {

            return orderEngine.GetOrderConfirmation();
        }


        public List<OrderItem> GetOrderItems()
        {
            return orderEngine.GetOrderItems();
        }

        public List<LineItem> GetLineItems()
        {
            return orderEngine.GetLineItems();
        }



        /// <summary>
        /// Behavior for checkbox isProcessed on OrderGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cboxProcessed_CheckedChanged(object sender, EventArgs e)
        {

            //CheckBox chk = (CheckBox)sender;
            //GridViewRow gr = (GridViewRow)chk.Parent.Parent;
            ////lblmsg.Text = OrderGridView.DataKeys[gr.RowIndex].Value.ToString();

            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex + 1;

            //Change the status or the order
            var order = (from myorder in ctx.Orders
                         where myorder.OrderId == rowIndex // get the corresponding order
                         select myorder).First();  // this will fetch the record.

            order.Processed = DateTime.Now.ToString();
            order.IsProcessed = true;

            //Session["Error"] = rowIndex;
            //Response.Redirect("/UserPages/ErrorPage.aspx");

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

                Session["Error"] = fullErrorMessage;

                Response.Redirect("ErrorPage.aspx");

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            finally
            {
                Response.Redirect("/Secure/Staff/ProcessOrders.aspx");
            }
        }

        /// <summary>
        /// Delete row  on OrderGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OrderGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int orderId = (int)e.Keys[0];
            var order = ctx.Orders.Find(orderId);
            ctx.Orders.Remove(order);
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

                Session["Error"] = fullErrorMessage;

                Response.Redirect("ErrorPage.aspx");

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            finally
            {
                Response.Redirect("/Secure/Staff/ProcessOrders.aspx");
            }
        }





        protected void ProductGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int lineItemId = (int)e.Keys[0];
            var lineItem = ctx.LineItems.Find(lineItemId);
            ctx.LineItems.Remove(lineItem);
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

                Session["Error"] = fullErrorMessage;

                Response.Redirect("ErrorPage.aspx");

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            finally
            {
                Response.Redirect("/Secure/Staff/ProcessOrders.aspx");
            }
        }

        protected void cboxProcessed_CheckedChanged1(object sender, EventArgs e)
        {

            //CheckBox chk = (CheckBox)sender;
            //GridViewRow gr = (GridViewRow)chk.Parent.Parent;
            ////lblmsg.Text = OrderGridView.DataKeys[gr.RowIndex].Value.ToString();

            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex + 1;

            //Change the status or the order
            var lineItem = (from myLineItems in ctx.LineItems
                            where myLineItems.LineItemId == rowIndex // get the corresponding order
                            select myLineItems).First();  // this will fetch the record.

            lineItem.Added = DateTime.Now.ToString();
            lineItem.IsAdded = true;

            //Session["Error"] = rowIndex;
            //Response.Redirect("/UserPages/ErrorPage.aspx");

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

                Session["Error"] = fullErrorMessage;

                Response.Redirect("ErrorPage.aspx");

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            finally
            {
                Response.Redirect("/Secure/Staff/ProcessOrders.aspx");
            }
        }




    }
}