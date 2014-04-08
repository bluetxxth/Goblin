using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoblinV1.UserPages
{
    /// <summary>
    /// This class provides a contact form with which a user can send email.
    /// </summary>
    public partial class ContactUs : System.Web.UI.Page
    {

        string m_name;
        string m_emailAddress;
        string m_subject;
        string m_messageBody;

        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }


       


        /// <summary>
        /// Provide access to the message body
        /// </summary>
        public string MessageBody
        {
            get { return m_messageBody; }
            set { m_messageBody = value; }
        }

        /// <summary>
        /// Provides access to the name text
        /// </summary>
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        /// <summary>
        /// Provides access to the email text
        /// </summary>
        public string EmailAddress
        {
            get { return m_emailAddress; }
            set { m_emailAddress = value; }
        }

        /// <summary>
        /// Provides access to the subject text
        /// </summary>
        public string Subject
        {
            get { return m_subject; }
            set { m_subject = value; }
        }


        /// <summary>
        /// Provide behavior for the clear button
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e"></param>
        protected void btnContactMsgClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtEmailAddress.Text = "";
            txtSubject.Text = "";
            txtMssgBody.Text = "";

        }
        /// <summary>
        /// provide behavior for the send button
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event argument</param>
        protected void btnContactMsgSend_Click(object sender, EventArgs e)
        {
            Name = txtName.Text;
            EmailAddress = txtEmailAddress.Text;
            Subject = txtSubject.Text;
            MessageBody = txtMssgBody.Text;

            Session["Name"] = Name.ToString();
            Session["Email"] = EmailAddress.ToString();
            Session["Subject"] = Subject.ToString();
            Session["MessageBody"] = MessageBody.ToString();

            try
            {
                Response.Redirect("~/UserPages/ContactUsConfirm.aspx");
     
            }
            catch (Exception ex)
            {
               Session["Error"] = ex;
               Response.Redirect("~/UserPages/ContactUsConfirm.aspx");
            }

            }


    }
}