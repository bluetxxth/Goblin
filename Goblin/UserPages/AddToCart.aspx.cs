using Goblin.BLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Goblin.UserPages
{
    public partial class AddToCart : System.Web.UI.Page
    {
        bool m_instock = false;

        private ShoppingCartEngine cartEngine = new ShoppingCartEngine();

        protected void Page_Load(object sender, EventArgs e)
        {

                string rawId = Request.QueryString["productID"];

                Session["productId"] = rawId;

                //Session["Error"] = rawId;

                //Response.Redirect("/UserPages/ErrorPage.aspx");

                int productId;

                if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
                {
                    using (ShoppingCartEngine usersShoppingCart = new ShoppingCartEngine())
                    {
                        usersShoppingCart.AddToCart(Convert.ToInt16(rawId));

                        //remove 1 unit from inventory
                      //  cartEngine.DiminishInventory();
                    }
                }
                else
                {
                    Debug.Fail("ERROR : We should never get to AddToCart.aspx without a ProductId.");
                    throw new Exception("ERROR : It is illegal to load AddToCart.aspx without setting a ProductId.");
                }

                Response.Redirect("ShoppingCart.aspx");
            }
        //}//end else
    }
}