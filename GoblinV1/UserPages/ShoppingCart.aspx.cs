
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using GoblinV1.Logic;
using GoblinV1.Models;



namespace GoblinV1.UserPages
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
       
        }

        public List<CartItem> GetShoppingCartItems()
        {
            ShoppingCartEngine engine = new ShoppingCartEngine();
            return engine.GetCartItems();
        }


    }
}