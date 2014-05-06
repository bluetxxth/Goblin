using Goblin.BLL;
using Goblin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Goblin.Secure._Roles
{
    public partial class RoleManager : System.Web.UI.Page
    {

        private AdminEngine m_adminEngine = new AdminEngine();


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    displayRolesInGrid();
            //}
            displayRolesInGrid();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CreateRoleButton_Click(object sender, EventArgs e)
        {
            string newRoleName = txtRoleToAdd.Text.Trim();

            //add role
            m_adminEngine.createRole(newRoleName);

            txtRoleToAdd.Text = string.Empty;

            HttpContext.Current.Response.Redirect("RoleManager.aspx");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RemoveRoleButton_Click(object sender, EventArgs e)
        {
            string removeRoleName = txtRoleToRemove.Text.Trim();

            //Remove role
            m_adminEngine.removeRole(removeRoleName);

            txtRoleToRemove.Text = string.Empty;

            HttpContext.Current.Response.Redirect("RoleManager.aspx");
        }

        /// <summary>
        /// 
        /// </summary>
        private void displayRolesInGrid()
        {

            RoleList.DataSource = m_adminEngine.getIdentityRoleList();
            RoleList.DataBind();

        }

    }
}