
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using GoblinV1.Logic;
using GoblinV1.Models;
using System.Web.ModelBinding;
using System.Data.Entity.Validation;



namespace GoblinV1.UserPages
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
  
        ShoppingCartEngine shoppingCart = new ShoppingCartEngine();

        private EntityMappingContext ctx = new EntityMappingContext();

        Product product = new Product();
        protected void Page_Load(object sender, EventArgs e)
        {

            GetTotals();
        }


        /// <summary>
        /// Get the shopping cart items
        /// </summary>
        /// <returns>a list of shopping cart items</returns>
        public List<CartItem> GetShoppingCartItems()
        {
            ShoppingCartEngine shoppingCart = new ShoppingCartEngine();


            return shoppingCart.GetCartItems();
        }


        public void  GetTotals()
        {
  
           string total = Convert.ToString(shoppingCart.GetTotal());

           lblTotal.Text = total;
        }

        /// <summary>
        /// Provide behavior for Continue Shopping button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UserPages/Products.aspx");
        }


        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            EntityMappingContext ctx = new EntityMappingContext();

            //instantiate store engine to get cart items
            ShoppingCartEngine cartEngine = new ShoppingCartEngine();

            

            //create an order status object in order to set it to submitted
            OrderStatus orderstatus = ctx.OrderStatuses.Create();

            //create order
            Order order = ctx.Orders.Create();

            //get the cart items
            List<CartItem> cartItemList = cartEngine.GetCartItems();


            Session["CartItems"] = cartItemList;
    
            
            orderstatus.Status = "Created " + DateTime.Now.ToString();

            //Session["Error"] = orderstatus.Status;
            //Response.Redirect("/UserPages/ErrorPage.aspx");


             try
            {
                ctx.OrderStatuses.Add(orderstatus);
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
             finally
             {
                 Response.Redirect("/UserPages/CreateUser.aspx");
             }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }


    }
}