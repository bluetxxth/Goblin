using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Goblin.UserPages
{


    public partial class TestPage : System.Web.UI.Page
    {

        string error = "";

        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!(Session["ValidationError"] == null))
            {
                try
                {
                    error = Session["ValidationError"].ToString();
                    lblError.Text = "Validation Errors found: ";

                    //better show this in a multiline textBox in order to break line easily
                    tokenizeString(error);

                }
                catch
                {
                    Debug.Write("What the #@@#@ is going on!" + lblError.Text);
                }

            }

            //Error message for stock
            if (!(Session["StockError"] == null))
            {
                error = Session["StockError"].ToString();

                try
                {
                    lblError.Text = error;

                }
                catch
                {
                    Debug.Write("What the #@@#@ is going on!" + lblError.Text);
                }
            }
            //error message for validation
            else if (!(Session["Error"] == null))
            {
                try
                {
                    error = Session["Error"].ToString();
                    lblError.Text = error;
                }
                catch
                {
                    Debug.Write("What the #@@#@ is going on!" + lblError.Text);
                }

            }
        }

        /// <summary>
        /// Split string in several tokens
        /// </summary>
        public void tokenizeString(string sessionError)
        {
            char[] delimiterChars = { ';' };

            string text = sessionError.Trim();
  
            string[] words = text.Split(delimiterChars);

            foreach (string s in words)
            {

                txtError.Text += Environment.NewLine + s.Trim();
            }

        }


        /// <summary>
        /// Behavior for back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            //stock error
            if (!(Session["StockError"] == null))
            {
                btnBack.Visible = true;
                Response.Redirect("Admin.aspx");

            }
            //Validation Error
            if (!(Session["ValidationError"] == null))
            {

                btnBack.Visible = true;
                Response.Redirect("/UserPages/EnterUserData.aspx");
            }

            //Whatever error
            if (!(Session["Error"] == null))
            {
                btnBack.Visible = false;

            }
        }
    }

}