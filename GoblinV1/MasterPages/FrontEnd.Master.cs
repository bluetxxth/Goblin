using GoblinV1.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoblinV1.MasterPages
{
    public partial class FrontEnd : System.Web.UI.MasterPage
    {

        /// <summary>
        /// Perform actions common to all requests
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = System.Web.HttpContext.Current.User.Identity.Name;

            lblLoggedUser.Text = user;

            //if (Customer.Identity.IsAuthenticated)
            //{
            //    ViewState["username"] = Page.User.Identity.Name;
            //    if (Customer.IsInRole("Admin"))
            //    {
            //        ViewState["Admin"] = "User is in the Admin Role";
            //        Menu1.Visible = true;
            //    }
            //    else if (Customer.IsInRole("Member"))
            //    {
            //        ViewState["Member"] = "User is in the Member Role";
            //        Menu2.Visible = true;
            //    }
            //    else if (Customer.IsInRole("RegisteredOnly"))
            //    {
            //        ViewState["RegisteredOnly"] = "User is in the RegisteredOnly Role";
            //        Menu3.Visible = true;
            //    }
            //}
            //else
            //    Menu4.Visible = true;

            Menu1.Visible = true;
            Menu2.Visible = true;

        }


        /// <summary>
        /// Perform any updates before the output is rendered. Any  changes at this point
        ///  to the state of the control can be saved and the ones in the rendering phase are lost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            using (ShoppingCartEngine usersShoppingCart = new ShoppingCartEngine())
            {
        
                //format the cart count
                string cartStr = string.Format("Cart [{0}]", usersShoppingCart.GetCount());

                if (cartStr != null)
                {
                    try
                   {
                        cartCount.InnerText = cartStr;
                   }
                    catch (Exception ex)
                    {
                        HttpContext.Current.Session["Error"] = ex;
                        HttpContext.Current.Response.Redirect("/UserPages/ErrorPage.aspx");
                    }
                }
                
                if (usersShoppingCart.GetCount() > 0)
                {
                    contentCartCounter.Visible = true;
                }
                else
                {
                    contentCartCounter.Visible = false;
                }
          
            }
        }
    }
}