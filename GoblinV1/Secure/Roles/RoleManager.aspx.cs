using GoblinV1.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoblinV1.Secure._Roles
{
    public partial class RoleManager : System.Web.UI.Page
    {

        private AdminEngine m_adminEngine = new AdminEngine();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                displayRolesInGrid();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CreateRoleButton_Click(object sender, EventArgs e)
        {
            string newRoleName = RoleName.Text.Trim();

            //add role
            m_adminEngine.createRole(newRoleName);

            RoleName.Text = string.Empty;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RemoveRoleButton_Click(object sender, EventArgs e)
        {
            string newRoleName = RoleName.Text.Trim();

            //Remove role
            m_adminEngine.removeRole(newRoleName);

            RoleName.Text = string.Empty;
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