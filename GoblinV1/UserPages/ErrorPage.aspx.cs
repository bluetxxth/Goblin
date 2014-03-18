using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoblinV1.UserPages
{


    public partial class TestPage : System.Web.UI.Page
    {

        string error = "";


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!(Session["Error"] == null))
            {
                error = Session["Error"].ToString();

                try
                {
                    lblError.Text = error;

                }
                catch (Exception ex)
                {
                    Debug.Write("What the #@@#@ is going on!" + lblError.Text);
                }
            }
            else
            {

                error = "no error session is passed";

            }


        }
    }
        
}