using GoblinV1.Logic;
using GoblinV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoblinV1.Secure._Roles
{
    public partial class AssignUsersToRoles : System.Web.UI.Page
    {
        private AdminEngine m_adminEngine = new AdminEngine();


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
            List<ApplicationUser> users = m_adminEngine.getApplicationUserList(); ;
            drpUserList.DataSource = users;
            drpUserList.DataBind();

        }

        /// <summary>
        /// 
        /// </summary>
        private void BindRolesToList()
        {
            List<string> roles = m_adminEngine.getIdentityRoleList();
            rptUsersRoleList.DataSource = roles;
            rptUsersRoleList.DataBind();

        }


        /// <summary>
        /// Check for roles for selected user
        /// </summary>
        private void checRolesForSelectedUser()
        {

            //get the selected user value from the dropdown list
            string selectedUserName = drpUserList.SelectedValue;

            var user = new ApplicationUser() { UserName = selectedUserName };

            // string[] selectedUserRoles = m_adminEngine.MyUserManager.GetRoles(selectedUserName).ToArray();

            List<string> selectedUserRoles = m_adminEngine.getIdentityUserRoles(user);

            //loop through the repeater's Items and check or uncheck the checkbox as needed
            foreach (RepeaterItem repeaterItem in rptUsersRoleList.Items)
            {

                //programatically reference the checkbox
                CheckBox chkboxRoleCheckBox = repeaterItem.FindControl("chkboxRoleCheckBox") as CheckBox;
                //see if chckboxRoleCheckBox text is  in the selectedUserRoles
                if (selectedUserRoles.Contains<string>(chkboxRoleCheckBox.Text))
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
            if (chkboxRoleCheckBox.Checked)
            {

                //add user to role for identity if checked
                m_adminEngine.addUserToRole(selectedUserName, roleName);

                //display a status message
                ActionStatus.Text = string.Format("User {0} was added to role {1}", selectedUserName, roleName);
            }
            else
            {
                //Remove user from role if checked


                //remove user to role if checked
                m_adminEngine.removeUserFromRole(selectedUserName, roleName);

                // Display a status message 
                ActionStatus.Text = string.Format("User {0} was removed from role {1}.", selectedUserName, roleName);
            }
        }
    }
}