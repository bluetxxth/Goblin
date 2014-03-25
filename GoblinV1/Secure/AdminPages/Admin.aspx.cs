using GoblinV1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoblinV1.Secure.AdminPages
{
    public partial class Admin : System.Web.UI.Page
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //check if the page is the result of a postback
            if (!Page.IsPostBack)
            {
                //bind users
                BindUserTolist();

                //Bind roles
                BindRolesToList();

                //check roles for selected user
                checRolesForSelectedUser();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void BindUserTolist()
        {
            //get all the user accounts
            MembershipUserCollection users = Membership.GetAllUsers();
            drpUserList.DataSource = users;
            drpUserList.DataBind();

        }

        /// <summary>
        /// 
        /// </summary>
        private void BindRolesToList()
        {

            //IEnumerable is a collection of a specified type
            string[] roles = Roles.GetAllRoles();
            rptUsersRoleList.DataSource = roles;
            rptUsersRoleList.DataBind();

        }

        /// <summary>
        /// 
        /// </summary>
        private void checRolesForSelectedUser()
        {
            //get the selected user value from the dropdown list
            string selectedUserName = drpUserList.SelectedValue;

            //get the  registered roles for the user
            string[] selectedUserRoles = Roles.GetRolesForUser(selectedUserName);

            //loop through the repeater's Items and check or uncheck the checkbox as needed
            foreach (RepeaterItem repeaterItem in rptUsersRoleList.Items){

                //programatically reference the checkbox
                CheckBox chkboxRoleCheckBox = repeaterItem.FindControl("chkboxRoleCheckBox") as CheckBox;
                //see if chckboxRoleCheckBox text is  in the selectedUserRoles
                if(selectedUserRoles.Contains<string>(chkboxRoleCheckBox.Text))
                {
                    chkboxRoleCheckBox.Checked = true;
                }
                else
                {
                    chkboxRoleCheckBox.Checked = false;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void setRoles()
        {
            MembershipUser newUser = Membership.CreateUser("Ruchira", "Password");
            Roles.AddUserToRole("Ruchira", "Role");
        }


        /// <summary>
        /// Behavior for dropdown user list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drpUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            checRolesForSelectedUser();
        }

        protected void chkboxRoleCheckBox_CheckedChanged(object sender, EventArgs e)
        { 
            //reference the checkbox that raised this event
            CheckBox chkboxRoleCheckBox = sender as CheckBox;

            //get the currently selected user
            string selectedUserName = drpUserList.SelectedValue;

            //get the currently selected role
            string roleName = chkboxRoleCheckBox.Text;

            //check if role checkbox is checked
            if(chkboxRoleCheckBox.Checked){

                //add user to role if checked
                Roles.AddUserToRole(selectedUserName, roleName);

                //display a status message
                ActionStatus.Text = string.Format("User {0} was removed from role {1}", selectedUserName, roleName);
            }
            else
            {
                //add user to role if checked
                Roles.RemoveUserFromRole(selectedUserName, roleName);

                // Display a status message 
                ActionStatus.Text = string.Format("User {0} was removed from role {1}.", selectedUserName, roleName);
            }
        }
    }
}