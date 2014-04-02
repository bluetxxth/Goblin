
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
using System.Collections.Specialized;
using System.Collections;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GoblinV1.UserPages
{
    /// <summary>
    /// Class responsible for the shopping cart functions
    /// </summary>
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

        /// <summary>
        /// Get total cost
        /// </summary>
        public void GetTotals()
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
            Response.Redirect("Products.aspx");
        }



        /// <summary>
        /// Provide behavior for checkout button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            EntityMappingContext ctx = new EntityMappingContext();

            //instantiate store engine to get cart items
            ShoppingCartEngine cartEngine = new ShoppingCartEngine();


            //create an order status object in order to set it to submitted
            OrderStatus orderstatus = ctx.OrderStatuses.Create();

            //get the cart items
            List<CartItem> cartItemList = cartEngine.GetCartItems();

            // Session["CartItems"] = cartItemList;

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

                Response.Redirect("ErrorPage.aspx");

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }


            AdminEngine adminEngine = new AdminEngine();

            //// && System.Web.HttpContext.Current.User.IsInRole("user")
            //&& System.Web.HttpContext.Current.User.IsInRole("Customer")

            string user = System.Web.HttpContext.Current.User.Identity.Name;

            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            store.AutoSaveChanges = false;

            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(store);
            var currentUser = manager.FindById(User.Identity.GetUserId());



            //if the current user is null he is not authenticated
            if (!(currentUser == null))
            {
                //If the object to be checked is null create it
                if (currentUser.MyUserCCardInfo == null)
                {
                    //creating object
                    currentUser.MyUserCCardInfo = new MyUserCCardInfo();
                    //go to enter data
                    Response.Redirect("/UserPages/EnterUserData.aspx");

                }
                else
                {   //If the credit card number is not null the record exists
                    //and just confirmation is required
                    if (!(currentUser.MyUserCCardInfo.CardNumber == null))
                    {
                        //go to confirm
                        Response.Redirect("/Secure/UserPagesSecured/ConfirmOrder.aspx");
                    }
                    else
                    {
                        //if not then enter user data
                        Response.Redirect("/UserPages/EnterUserData.aspx");

                    }
                }

            }
            //if the user is not authenticated then make sure he is logged out and send him to login
            else
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                authenticationManager.SignOut();
                HttpContext.Current.Response.Redirect("~/Account/Login.aspx");
            }

            //check if the credit card number is null if not then just confirm
            if (!(currentUser.MyUserCCardInfo.CardNumber == null))
            {
                //go to confirm
                Response.Redirect("/Secure/UserPagesSecured/ConfirmOrder.aspx");
            }

            //if the user name is null then login
            if (user == null)
            {
                HttpContext.Current.Response.Redirect("~/Account/Login.aspx");
            }

        }


        /// <summary>
        /// Update the cart items
        /// </summary>
        /// <returns></returns>
        public List<CartItem> UpdateCartItems()
        {
            using (ShoppingCartEngine usersShoppingCart = new ShoppingCartEngine())
            {
                String cartId = usersShoppingCart.GetCartId();

                ShoppingCartEngine.ShoppingCartUpdates[] cartUpdates = new ShoppingCartEngine.ShoppingCartUpdates[CartList.Rows.Count];
                for (int i = 0; i < CartList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(CartList.Rows[i]);
                    cartUpdates[i].ProductId = Convert.ToInt32(rowValues["ProductID"]);

                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)CartList.Rows[i].FindControl("Remove");
                    cartUpdates[i].RemoveItem = cbRemove.Checked;

                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox = (TextBox)CartList.Rows[i].FindControl("PurchaseQuantity");
                    cartUpdates[i].PurchaseQuantity = Convert.ToInt16(quantityTextBox.Text.ToString());
                }
                usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates.ToList());
                CartList.DataBind();
                lblTotal.Text = String.Format("{0:c}", usersShoppingCart.GetTotal());
                return usersShoppingCart.GetCartItems();
            }
        }

        /// <summary>
        /// Get the values from cell
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // Extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }

        /// <summary>
        /// Provide behavior for button update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateCartItems();
        }

        protected void CartList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}