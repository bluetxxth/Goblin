using GoblinV1.Logic;
using GoblinV1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoblinV1.Secure.UserPagesSecured
{
    public partial class UserAdminPanel : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindGridUserInfo();
                BindGridCreditCardInfo();
                BindBillingAddressInfo();
                BindShippingAddressInfo();
            }
            lblMessage.Text = "";

        }


        /// <summary>
        /// Bind Customer data to grid
        /// </summary>
        void BindGridUserInfo()
        {

            using (EntityMappingContext context = new EntityMappingContext())
            {

                string user = System.Web.HttpContext.Current.User.Identity.Name;

                var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                store.AutoSaveChanges = false;

                var currentUserId = User.Identity.GetUserId();
                var manager = new UserManager<ApplicationUser>(store);
                var currentUser = manager.FindById(User.Identity.GetUserId());

                

                if (currentUser == null)
                {
                    var obj = new List<MyUserInfo>();
                    obj.Add(new MyUserInfo());

                    List<MyUserInfo> myUserInfoList = new List<MyUserInfo>();
                    myUserInfoList.Add(currentUser.MyUserInfo);

                    gridUser.DataSource = myUserInfoList.ToList().Where(elem => elem != null);
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
                    myUserInfoList.Add(currentUser.MyUserInfo);

                    gridUser.DataSource = myUserInfoList.ToList().Where(elem => elem != null);
                    gridUser.DataBind();
                }
            }
        }

        /// <summary>
        /// Cystiner Riw command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


        /// <summary>
        /// Customer row edit cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
             gridUser.EditIndex = -1;
             BindGridUserInfo();
        }

        /// <summary>
        /// customer row edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridUser.EditIndex = e.NewEditIndex;
            BindGridUserInfo();

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

            ApplicationUser appuserContext = new ApplicationUser();


            GridViewRow row = gridUser.Rows[e.RowIndex];
            TextBox txtFirstName = row.FindControl("txtFirstName") as TextBox;
            TextBox txtMiddleName = row.FindControl("txtMiddleName") as TextBox;
            TextBox txtLastName = row.FindControl("txtLastName") as TextBox;
            TextBox txtEmail = row.FindControl("txtEmail") as TextBox;
            TextBox txtTelephone = row.FindControl("txtTelephone") as TextBox;
            TextBox txtCellphone = row.FindControl("txtCellphone") as TextBox;

            //DropDownList ddlCategory = row.FindControl("ddlCategory") as DropDownList;
            if (txtFirstName != null && txtLastName != null && txtEmail != null && txtTelephone != null && txtCellphone != null && txtMiddleName != null)
            {
                using (EntityMappingContext context = new EntityMappingContext())
                {

                    int customerID = Convert.ToInt32(gridUser.DataKeys[e.RowIndex].Value);
                    Customer obj = context.Customers.First(x => x.CustomerId == customerID);
                    currentUser.MyUserInfo.FirstName = txtFirstName.Text;
                    currentUser.MyUserInfo.LastName = txtLastName.Text;
                    currentUser.MyUserInfo.Email = txtEmail.Text;
                    currentUser.MyUserInfo.MiddleName = txtMiddleName.Text;
                    currentUser.MyUserInfo.Cellphone = txtCellphone.Text;
                    currentUser.MyUserInfo.Telephone = txtTelephone.Text;
                    //obj.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                    store.Context.SaveChanges();
                    lblMessage.Text = "Saved successfully.";
                    gridUser.EditIndex = -1;
                    BindGridUserInfo();
                }
            }
        }

        /// <summary>
        /// bind customer row 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //DropDownList ddl = null;
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    ddl = e.Row.FindControl("ddlCategoryNew") as DropDownList;
            //}
            ////if (e.Row.RowType == DataControlRowType.DataRow)
            ////{
            ////    ddl = e.Row.FindControl("ddlCategory") as DropDownList;
            ////}
            //if (ddl != null)
            //{
            //    using (EntityMappingContext context = new EntityMappingContext())
            //    {
            //        ddl.DataSource = context.Categories;
            //        ddl.DataTextField = "Name";
            //        //ddl.DataValueField = "CategoryID";
            //        ddl.DataBind();
            //        ddl.Items.Insert(0, new ListItem(""));
            //    }
            //    //if (e.Row.RowType == DataControlRowType.DataRow)
            //    //{
            //    //    ddl.SelectedValue = ((Customer)(e.Row.DataItem)).CategoryID.ToString();
            //    //}
            //}
        }


        ///     MyUserCCardInfoes
        /// -------------------------------------------------------------------------------------
        /// 


        /// <summary>
        /// Bind Customer data to grid
        /// </summary>
        void BindGridCreditCardInfo()
        {

            using (EntityMappingContext context = new EntityMappingContext())
            {

                string user = System.Web.HttpContext.Current.User.Identity.Name;

                var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                store.AutoSaveChanges = false;

                var currentUserId = User.Identity.GetUserId();
                var manager = new UserManager<ApplicationUser>(store);
                var currentUser = manager.FindById(User.Identity.GetUserId());

                if (currentUser == null)
                {
                    var obj = new List<MyUserInfo>();
                    obj.Add(new MyUserInfo());

                    List<MyUserCCardInfo> myUserCCardInfo = new List<MyUserCCardInfo>();
                    myUserCCardInfo.Add(currentUser.MyUserCCardInfo);

                    gridCreditCard.DataSource = myUserCCardInfo.ToList().Where(elem => elem != null); ;
                    gridCreditCard.DataBind();

                    int columnsCount = gridCreditCard.Columns.Count;
                    gridCreditCard.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridCreditCard.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridCreditCard.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridCreditCard.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridCreditCard.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridCreditCard.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridCreditCard.Rows[0].Cells[0].Text = "NO RESULT FOUND!";

                }
                else
                {

                    //List<MyUserInfo> myUserInfoList = new List<MyUserInfo>();
                    //myUserInfoList.Add(currentUser.MyUserInfo);

                    //gridUser.DataSource = myUserInfoList.ToList();
                    //gridUser.DataBind();

                    List<MyUserCCardInfo> myUserCCardInfo = new List<MyUserCCardInfo>();
                    myUserCCardInfo.Add(currentUser.MyUserCCardInfo);

                    gridCreditCard.DataSource = myUserCCardInfo.ToList().Where(elem => elem != null); ;
                    gridCreditCard.DataBind();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridCreditCard_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        /// <summary>
        /// Cancel edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridCreditCard_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridCreditCard.EditIndex = -1;
            BindGridCreditCardInfo();
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridCreditCard_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridCreditCard.EditIndex = e.NewEditIndex;
            BindGridCreditCardInfo();
        }

        /// <summary>
        /// Binding row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridCreditCard_RowDataBound(object sender, GridViewRowEventArgs e)
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
        /// Update row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridCreditCard_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string user = System.Web.HttpContext.Current.User.Identity.Name;

            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            store.AutoSaveChanges = false;

            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(store);
            var currentUser = manager.FindById(User.Identity.GetUserId());

            ApplicationUser appuserContext = new ApplicationUser();


            GridViewRow row = gridUser.Rows[e.RowIndex];
            TextBox txtCardName = row.FindControl("txtCardName") as TextBox;
            TextBox txtCardNumber = row.FindControl("txtCardNumber") as TextBox;
            TextBox txtCardExpiryDate = row.FindControl("txtCardExpiryDate") as TextBox;
            TextBox txtCardSecurityCode = row.FindControl("txtCardSecurityCode") as TextBox;
       
            //DropDownList ddlCategory = row.FindControl("ddlCategory") as DropDownList;
            if (txtCardName != null && txtCardNumber != null && txtCardExpiryDate != null && txtCardSecurityCode != null )
            {
                using (EntityMappingContext context = new EntityMappingContext())
                {

                    int customerID = Convert.ToInt32(gridUser.DataKeys[e.RowIndex].Value);
                    Customer obj = context.Customers.First(x => x.CustomerId == customerID);

                    currentUser.MyUserCCardInfo.CardName = txtCardName.Text;
                    currentUser.MyUserCCardInfo.CardNumber= txtCardNumber.Text;
                    currentUser.MyUserCCardInfo.CardExpiryDate = txtCardExpiryDate.Text;
                    currentUser.MyUserCCardInfo.CardSecurityCode= txtCardSecurityCode.Text;
                    //obj.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                    store.Context.SaveChanges();
                    lblMessage.Text = "Saved successfully.";
                    gridCreditCard.EditIndex = -1;
                    BindGridCreditCardInfo();
                }
            }
        }


        ///     Section MyUserBillingAddress
        /// ------------------------------------------------------------------------------------------------
        /// 


        /// <summary>
        /// Bind Customer data to grid
        /// </summary>
        void BindBillingAddressInfo()
        {

            using (EntityMappingContext context = new EntityMappingContext())
            {

                string user = System.Web.HttpContext.Current.User.Identity.Name;

                var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                store.AutoSaveChanges = false;

                var currentUserId = User.Identity.GetUserId();
                var manager = new UserManager<ApplicationUser>(store);
                var currentUser = manager.FindById(User.Identity.GetUserId());

                if (currentUser == null)
                {
                    var obj = new List<MyUserBillingAddress>();
                    obj.Add(new MyUserBillingAddress());

                    List<MyUserBillingAddress> myUserBillingAddress = new List<MyUserBillingAddress>();
                    myUserBillingAddress.Add(currentUser.BillingAddress);

                    gridBillingAddress.DataSource = myUserBillingAddress.ToList().Where(elem => elem != null); ;
                    gridBillingAddress.DataBind();

                    int columnsCount = gridCreditCard.Columns.Count;
                    gridBillingAddress.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridBillingAddress.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridBillingAddress.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridBillingAddress.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridBillingAddress.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridBillingAddress.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridBillingAddress.Rows[0].Cells[0].Text = "NO RESULT FOUND!";

                }
                else
                {
                    //List<MyUserInfo> myUserInfoList = new List<MyUserInfo>();
                    //myUserInfoList.Add(currentUser.MyUserInfo);

                    //gridUser.DataSource = myUserInfoList.ToList();
                    //gridUser.DataBind();

                    List<MyUserBillingAddress> myUserBillingAddress = new List<MyUserBillingAddress>();
                    myUserBillingAddress.Add(currentUser.BillingAddress);

                    gridBillingAddress.DataSource = myUserBillingAddress.ToList().Where(elem => elem != null); ;
                    gridBillingAddress.DataBind();
                }
            }
        }

        protected void gridBillingAddress_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        /// <summary>
        /// Cancel billing address edit row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBillingAddress_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridBillingAddress.EditIndex = -1;
            BindBillingAddressInfo();
        }

        /// <summary>
        /// Edit billing address row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBillingAddress_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridBillingAddress.EditIndex = e.NewEditIndex;
            BindBillingAddressInfo();
        }

        /// <summary>
        /// Bind billing address row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBillingAddress_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gridBillingAddress_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string user = System.Web.HttpContext.Current.User.Identity.Name;

            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            store.AutoSaveChanges = false;

            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(store);
            var currentUser = manager.FindById(User.Identity.GetUserId());

            ApplicationUser appuserContext = new ApplicationUser();

            GridViewRow row = gridBillingAddress.Rows[e.RowIndex];
            TextBox txtBillingAddressName = row.FindControl("txtBillingAddressName") as TextBox;
            TextBox txtBillingAddressNumber = row.FindControl("txtBillingAddressNumber") as TextBox;
            TextBox txtBillingStair = row.FindControl("txtBillingStair") as TextBox;
            TextBox txtBillingApartment = row.FindControl("txtBillingApartment") as TextBox;
            TextBox txtBillingCity = row.FindControl("txtBillingCity") as TextBox;
            TextBox txtBillingCountry = row.FindControl("txtBillingCountry") as TextBox;
            TextBox txtBillingZipcode = row.FindControl("txtBillingZipcode") as TextBox;
       
            //DropDownList ddlCategory = row.FindControl("ddlCategory") as DropDownList;
            if (txtBillingAddressName != null && txtBillingAddressNumber != null && txtBillingStair != null && txtBillingApartment != null && txtBillingCity != null && txtBillingCountry != null && txtBillingZipcode != null)
            {
                using (EntityMappingContext context = new EntityMappingContext())
                {

                    int customerID = Convert.ToInt32(gridUser.DataKeys[e.RowIndex].Value);
                    Customer obj = context.Customers.First(x => x.CustomerId == customerID);
                    currentUser.BillingAddress.AddressName = txtBillingAddressName.Text;
                    currentUser.BillingAddress.AddressNumber = txtBillingAddressNumber.Text;
                    currentUser.BillingAddress.Stair = txtBillingStair.Text;
                    currentUser.BillingAddress.Apartment = txtBillingApartment.Text;
                    currentUser.BillingAddress.Country = txtBillingCountry.Text;
                    currentUser.BillingAddress.City = txtBillingCity.Text;
                    currentUser.BillingAddress.Zipcode = txtBillingZipcode.Text;
                    //obj.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                    store.Context.SaveChanges();
                    lblMessage.Text = "Saved successfully.";
                    gridBillingAddress.EditIndex = -1;
                    BindBillingAddressInfo();
                }
            }
        }


        ///     Section MyUserShippingAddress
        /// ----------------------------------------------------------------------------------------
        ///

        /// <summary>
        /// Bind Shipping Address info data to grid
        /// </summary>
        void BindShippingAddressInfo()
        {

            using (EntityMappingContext context = new EntityMappingContext())
            {

                string user = System.Web.HttpContext.Current.User.Identity.Name;

                var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                store.AutoSaveChanges = false;

                var currentUserId = User.Identity.GetUserId();
                var manager = new UserManager<ApplicationUser>(store);
                var currentUser = manager.FindById(User.Identity.GetUserId());

                if (currentUser == null)
                {
                    var obj = new List<MyUserInfo>();
                    obj.Add(new MyUserInfo());

                    //gridShippingAddress.DataSource = currentUser.ShippingAddress;
                    //gridShippingAddress.DataSource = obj.ToList();
                    //gridShippingAddress.DataBind();

                    List<MyUserShippingAddress> myUserShippingAddress = new List<MyUserShippingAddress>();
                    myUserShippingAddress.Add(currentUser.ShippingAddress);

                    gridShippingAddress.DataSource = myUserShippingAddress.ToList().Where(elem => elem != null); ;
                    gridShippingAddress.DataBind();

                    int columnsCount = gridCreditCard.Columns.Count;
                    gridShippingAddress.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridShippingAddress.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridShippingAddress.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridShippingAddress.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridShippingAddress.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridShippingAddress.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridShippingAddress.Rows[0].Cells[0].Text = "NO RESULT FOUND!";

                }
                else
                {

                    //List<MyUserInfo> myUserInfoList = new List<MyUserInfo>();
                    //myUserInfoList.Add(currentUser.MyUserInfo);

                    //gridUser.DataSource = myUserInfoList.ToList();
                    //gridUser.DataBind();

                    List<MyUserShippingAddress> myUserShippingAddress = new List<MyUserShippingAddress>();
                    myUserShippingAddress.Add(currentUser.ShippingAddress);

                    gridShippingAddress.DataSource = myUserShippingAddress.ToList().Where(elem => elem != null); ;
                    gridShippingAddress.DataBind();
                }
            }
        }

        protected void gridShippingAddress_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        /// <summary>
        /// Cancel edit shipping address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridShippingAddress_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridShippingAddress.EditIndex = -1;
            BindShippingAddressInfo();
        }

        /// <summary>
        /// Edit row shipping address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridShippingAddress_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridShippingAddress.EditIndex = e.NewEditIndex;
            BindShippingAddressInfo();
        }

        /// <summary>
        /// Bind row shipping address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridShippingAddress_RowDataBound(object sender, GridViewRowEventArgs e)
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridShippingAddress_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string user = System.Web.HttpContext.Current.User.Identity.Name;

            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            store.AutoSaveChanges = false;

            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(store);
            var currentUser = manager.FindById(User.Identity.GetUserId());

            ApplicationUser appuserContext = new ApplicationUser();

            GridViewRow row = gridBillingAddress.Rows[e.RowIndex];
            TextBox txtShippingAddressName = row.FindControl("txtShippingAddressName") as TextBox;
            TextBox txtShippingAddressNumber = row.FindControl("txtShippingAddressNumber") as TextBox;
            TextBox txtShippingStair = row.FindControl("txtShippingStair") as TextBox;
            TextBox txtShippingApartment = row.FindControl("txtShippingApartment") as TextBox;
            TextBox txtShippingCity = row.FindControl("txtShippingCity") as TextBox;
            TextBox txtShippingCountry = row.FindControl("txtShippingCountry") as TextBox;
            TextBox txtShippingZipcode = row.FindControl("txtShippingZipcode") as TextBox;

            //DropDownList ddlCategory = row.FindControl("ddlCategory") as DropDownList;
            if (txtShippingAddressName != null && txtShippingAddressNumber != null && txtShippingStair != null && txtShippingApartment != null && txtShippingCity != null && txtShippingCountry != null && txtShippingZipcode != null)
            {
                using (EntityMappingContext context = new EntityMappingContext())
                {

                    int customerID = Convert.ToInt32(gridUser.DataKeys[e.RowIndex].Value);
                    Customer obj = context.Customers.First(x => x.CustomerId == customerID);
                    currentUser.BillingAddress.AddressName = txtShippingAddressName.Text;
                    currentUser.BillingAddress.AddressNumber = txtShippingAddressNumber.Text;
                    currentUser.BillingAddress.Stair = txtShippingStair.Text;
                    currentUser.BillingAddress.Apartment = txtShippingApartment.Text;
                    currentUser.BillingAddress.Country = txtShippingCountry.Text;
                    currentUser.BillingAddress.City = txtShippingCity.Text;
                    currentUser.BillingAddress.Zipcode = txtShippingZipcode.Text;
                    //obj.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                    store.Context.SaveChanges();
                    lblMessage.Text = "Saved successfully.";
                    gridShippingAddress.EditIndex = -1;
                    BindShippingAddressInfo();
                }
            }
        }












    }
}

