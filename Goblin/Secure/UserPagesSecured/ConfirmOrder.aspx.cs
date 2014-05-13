using Goblin.BLL;
using Goblin.Model;
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
using System.Diagnostics;
using AjaxControlToolkit;


namespace Goblin.UserPages
{
    public partial class ConfirmOrder : System.Web.UI.Page
    {
        private int m_lastOrderId;
        private EntityMappingContext ctx = new EntityMappingContext();
        private IdentityDbContext idbctxt = new IdentityDbContext();
        private ShoppingCartEngine cartEngine = new ShoppingCartEngine();

        //instantiate store engine to get cart items
        private List<CartItem> m_items;
        private int m_lastOrderConfId;

        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Session["lastOrderConfId"].ToString() != null))
            {

                 m_lastOrderConfId = Convert.ToInt32(Session["lastOrderConfId"].ToString());
            }


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

            if (!Page.IsPostBack)
            {
                //Bind order confirmation to repeater when page loads first time
                bindOrderConfirmationToRepeater();
            }

        }

        /// <summary>
        /// Method to bind employee records to repeater control.
        /// </summary>
        void bindOrderConfirmationToRepeater()
        {

            using (EntityMappingContext context = new EntityMappingContext())
            {
                rptConfirmOrder.DataSource = (from oc in context.OrderConfirmations.ToList()
                                     
                                              where  oc.OrderConfirmationId == m_lastOrderConfId select oc);
                rptConfirmOrder.DataBind();
            }
        }


        /// <summary>
        /// Check exactly what is being passed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptConfirmOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var dataItem = e.Item.DataItem as OrderConfirmation;
                Debug.Assert(5 == dataItem.Quantity);
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

            try
            {

                ctx.OrderStatuses.Add(orderStatus);
              

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

                
                //Session["Error"] = m_items.Count;
                //Response.Redirect("/UserPages/ErrorPage.aspx");
               
                //traverse the cartItem list and reduce inventory on each item ordered
                for (int i = 0; i < m_items.Count; i++)
                {
                    cartEngine.DiminishInventory(m_items[i].ProductId, m_items[i].Quantity);

                }

                //empty the cart for next order
                cartEngine.EmptyCart();
                //to the shop
                HttpContext.Current.Response.Redirect("~/UserPages/Products.aspx");

            }
        }
    }
}