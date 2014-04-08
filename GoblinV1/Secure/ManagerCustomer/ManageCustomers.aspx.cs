using GoblinV1.Logic;
using GoblinV1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoblinV1.Secure.Staff
{
    public partial class ManageCustomers : System.Web.UI.Page
    {
        private EntityMappingContext ctx = new EntityMappingContext();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindGrid();
            }
            lblMessage.Text = "";

        }


        /// <summary>
        /// Bind Customer data to grid
        /// </summary>
        void BindGrid()
        {

            using (EntityMappingContext context = new EntityMappingContext())
            {

                string user = System.Web.HttpContext.Current.User.Identity.Name;

                var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                store.AutoSaveChanges = false;

                var currentUserId = User.Identity.GetUserId();
                var manager = new UserManager<ApplicationUser>(store);
                var currentUser = manager.FindById(User.Identity.GetUserId());

                ApplicationUser appUser = new ApplicationUser();

                ApplicationDbContext appContext = new ApplicationDbContext();


                if (appUser == null)
                {
                    var obj = new List<MyUserInfo>();
                    obj.Add(new MyUserInfo());

                    List<MyUserInfo> myUserInfoList = new List<MyUserInfo>();
                    myUserInfoList.Add(appUser.MyUserInfo);

                    //gridUser.DataSource = myUserInfoList.ToList().Where(elem => elem != null);
                    gridUser.DataSource = appContext.MyUserInfo.ToList().Where(elem => elem != null);
                    gridUser.DataBind();

                    int columnsCount = gridUser.Columns.Count;
                    gridUser.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridUser.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridUser.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridUser.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridUser.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridUser.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridUser.Rows[0].Cells[0].Text = "NO RESULT FOUND!";

                }
                else
                {
                    List<MyUserInfo> myUserInfoList = new List<MyUserInfo>();
                    myUserInfoList.Add(appUser.MyUserInfo);

                    //gridUser.DataSource = myUserInfoList.ToList().Where(elem => elem != null);
                    gridUser.DataSource = appContext.MyUserInfo.ToList().Where(elem => elem != null);
                    gridUser.DataBind();
                }
            }
        }


        /// <summary>
        /// Row commands
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string user = System.Web.HttpContext.Current.User.Identity.Name;

            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            store.AutoSaveChanges = false;

            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(store);
            var currentUser = manager.FindById(User.Identity.GetUserId());

            ApplicationUser appUser = new ApplicationUser();

 
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridUser.FooterRow;
                TextBox txtFirstName = row.FindControl("txtFirstNameNew") as TextBox;
                TextBox txtMiddleName = row.FindControl("txtMiddleNameNew") as TextBox;
                TextBox txtLastName = row.FindControl("txtLastNameNew") as TextBox;
                TextBox txtEmail = row.FindControl("txtEmailNew") as TextBox;
                TextBox txtTelephone = row.FindControl("txtTelephoneNew") as TextBox;
                TextBox txtCellPhone = row.FindControl("txtCellPhoneNew") as TextBox;
                //DropDownList ddlCategory = row.FindControl("ddlCategoryNew") as DropDownList;
                if (txtFirstName != null && txtMiddleName != null && txtLastName != null && txtEmail != null && txtTelephone != null && txtCellPhone != null)
                {
                    using (ApplicationDbContext appContext = new ApplicationDbContext())
                    {
         

                       
                        appUser.MyUserInfo.FirstName  = txtFirstName.Text;
                        appUser.MyUserInfo.MiddleName = txtMiddleName.Text;
                        appUser.MyUserInfo.LastName = txtLastName.Text;
                        appUser.MyUserInfo.Email = txtEmail.Text;
                        appUser.MyUserInfo.Telephone= txtTelephone.Text;
                        appUser.MyUserInfo.Cellphone = txtCellPhone.Text;
                        appContext.MyUserInfo.Add(appUser.MyUserInfo);
                        appContext.SaveChanges();

                        lblMessage.Text = "Added successfully.";
                        BindGrid();
                    }
                }
            }
        }


        /// <summary>
        ///Cancel customer row edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridUser.EditIndex = -1;
            BindGrid();
        }


        /// <summary>
        /// Customer Row edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridUser.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        /// <summary>
        /// Bind customer row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList ddl = null;
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlCategoryNew") as DropDownList;
            }
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    ddl = e.Row.FindControl("ddlCategory") as DropDownList;
            //}
            if (ddl != null)
            {
                using (EntityMappingContext context = new EntityMappingContext())
                {
                    ddl.DataSource = context.Categories;
                    ddl.DataTextField = "Name";
                    //ddl.DataValueField = "CategoryID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem(""));
                }
                //if (e.Row.RowType == DataControlRowType.DataRow)
                //{
                //    ddl.SelectedValue = ((Customer)(e.Row.DataItem)).CategoryID.ToString();
                //}
            }
        }


        /// <summary>
        /// Delete customer row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int customerID = Convert.ToInt32(gridUser.DataKeys[e.RowIndex].Value);

            string user = System.Web.HttpContext.Current.User.Identity.Name;

            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            store.AutoSaveChanges = false;

            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(store);
            var appUser = new ApplicationUser();


            using (ApplicationDbContext appContext = new ApplicationDbContext())
            {
                appContext.MyUserInfo.Remove(appUser.MyUserInfo);
                appContext.SaveChanges();
                BindGrid();
                lblMessage.Text = "Deleted successfully.";
            }
        }


        /// <summary>
        /// Update customer row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            string user = System.Web.HttpContext.Current.User.Identity.Name;

            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            store.AutoSaveChanges = false;

            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(store);
            var currentUser = manager.FindById(User.Identity.GetUserId());

            ApplicationUser appUser = new ApplicationUser();

            GridViewRow row = gridUser.Rows[e.RowIndex];
            TextBox txtFirstName = row.FindControl("txtFirstName") as TextBox;
            TextBox txtMiddleName = row.FindControl("txtMiddleName") as TextBox;
            TextBox txtLastName = row.FindControl("txtLastName") as TextBox;
            TextBox txtEmail = row.FindControl("txtEmail") as TextBox;
            TextBox txtTelephone = row.FindControl("txtTelephone") as TextBox;
            TextBox txtCellPhone = row.FindControl("txtCellPhone") as TextBox;

            //DropDownList ddlCategory = row.FindControl("ddlCategory") as DropDownList;
            if (txtFirstName != null && txtMiddleName != null && txtLastName != null && txtEmail != null && txtTelephone != null && txtCellPhone != null)
            {
                using (ApplicationDbContext appContext = new ApplicationDbContext())
                {
                    appUser.MyUserInfo.FirstName = txtFirstName.Text;
                    appUser.MyUserInfo.MiddleName = txtMiddleName.Text;
                    appUser.MyUserInfo.LastName = txtLastName.Text;
                    appUser.MyUserInfo.Email = txtEmail.Text;
                    appUser.MyUserInfo.Telephone = txtTelephone.Text;
                    appUser.MyUserInfo.Cellphone = txtCellPhone.Text;
                    appContext.SaveChanges();
                    lblMessage.Text = "Saved successfully.";
                    gridUser.EditIndex = -1;
                    BindGrid();
                }
            }

        }
    }
}