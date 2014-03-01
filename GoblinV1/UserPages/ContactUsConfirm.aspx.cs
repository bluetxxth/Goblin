using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoblinV1.UserPages
{
    /// <summary>
    /// Class provides for a confirmation section before an email is sent
    /// </summary>
    public partial class ContactUsConfirm : System.Web.UI.Page
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            string name = null;
            string email = null;
            string subject = null;
            string message = null;

            try
            {
                //name = Convert.ToString(Session["Name"]);
                //email = Convert.ToString(Session["Email"]);
                //subject = Convert.ToString(Session["Subject"]);
                //message = Convert.ToString(Session["Message"]);

                name = Session["Name"].ToString();
                email = Session["Email"].ToString();
                subject = Session["Subject"].ToString();
                message = Session["Message"].ToString();

            }
            catch (Exception ex)
            {
                txtOutput.Text = Environment.NewLine + ex.ToString();

                name = "Missing name";
                email = "Missing e-mail";
                subject = "Missing subject";
                message = "Missing message";
            }
            txtOutput.Text = Environment.NewLine + name;
            txtOutput.Text = Environment.NewLine + email;
            txtOutput.Text = Environment.NewLine + subject;
            txtOutput.Text = Environment.NewLine + message;

        }

    }
}