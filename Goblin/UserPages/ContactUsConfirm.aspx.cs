using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Goblin.UserPages
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


            if(Session["Name"].ToString() == null ){

                lblName.Text = "Error missing data go back";
                txtOutput.Text += "Missing name";
              
            }else{
                name = "Name: " + Session["Name"].ToString();
            }

            if(Session["Email"].ToString() == null)
            {
                lblName.Text = "Error missing data go back";
                txtOutput.Text += "Missing Email";
            }
            else
            {
               email =  "Email: " + Session["Email"].ToString();
            }


            if (Session["Subject"].ToString() == null)
            {
                lblName.Text = "Error missing data go back";
                txtOutput.Text += "Missing Subject";
            }
            else
            {
               subject = "Subject: " + Session["Subject"].ToString();
            }

            if (Session["MessageBody"].ToString() == null)
            {
                lblName.Text = "Error missing data go back";
                txtOutput.Text = "Missing Message body";
            }else {
                message= "Message: " + Session["MessageBody"].ToString();
            }

            if(name != null && email != null && subject != null && message != null ){
                 lblName.Text += "Message Successfully sent";

                txtOutput.Text = Environment.NewLine + name;
                txtOutput.Text += Environment.NewLine + email;
                txtOutput.Text += Environment.NewLine + subject;
                txtOutput.Text += Environment.NewLine + message;
          
            }
           

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            NoBotState state;
            // if condition to check the response state of NoBot
            if (NoBot1.IsValid(out state))
            {
                Label2.Text = state.ToString();
            }
            else
            {
                Label2.Text = state.ToString();
            }
            StringBuilder sb = new StringBuilder();
            // foreach loop to get cached IP address and datetime assocated with it(when last postback was occurred)
            foreach (System.Collections.Generic.KeyValuePair<DateTime, string> keyValue in NoBot.GetCopyOfUserAddressCache())
            {
                sb.AppendFormat("{0}: {1}<br />", keyValue.Key.ToString(), keyValue.Value);
            }
            Label4.Text = sb.ToString();
        }

    }
}