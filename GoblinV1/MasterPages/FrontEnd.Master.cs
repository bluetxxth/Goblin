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
        protected void Page_Load(object sender, EventArgs e)
        {
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

    }
}