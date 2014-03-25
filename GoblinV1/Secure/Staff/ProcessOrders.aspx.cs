using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoblinV1.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;
using GoblinV1.Logic;

namespace GoblinV1.Secure.Staff
{
    public partial class ProcessOrders : System.Web.UI.Page
    {

        private EntityMappingContext ctx = new EntityMappingContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Get orders
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrders()
        {
            OrderEngine orderEngine = new OrderEngine();
            return orderEngine.GetOrder();
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
                Response.Redirect("Admin.aspx");
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
                Response.Redirect("Admin.aspx");
            }
        }
    }
}