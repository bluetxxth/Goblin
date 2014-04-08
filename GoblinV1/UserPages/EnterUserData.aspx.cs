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

namespace GoblinV1.UserPages
{
    /// <summary>
    /// Class responsible for users additional data
    /// </summary>
    public partial class EnterUserData : System.Web.UI.Page
    {

        ShoppingCartEngine shoppingCart = new ShoppingCartEngine();
        /// <summary>
        /// entry point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Repsonsible for behavior of Create User button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string user = System.Web.HttpContext.Current.User.Identity.Name;

            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            store.AutoSaveChanges = false;

            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(store);
            var currentUser = manager.FindById(User.Identity.GetUserId());

            if(currentUser == null){
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                authenticationManager.SignOut();
                HttpContext.Current.Response.Redirect("~/Account/Login.aspx");
            }

            if(Page.IsValid){
          
            //instantiate MyUserInfo
            currentUser.MyUserInfo = new MyUserInfo();

            currentUser.MyUserInfo.FirstName = txtFirstName.Text;
            currentUser.MyUserInfo.MiddleName = txtMiddleName.Text;
            currentUser.MyUserInfo.LastName = txtLastName.Text;
            currentUser.MyUserInfo.Email = txtEmail.Text;
            currentUser.MyUserInfo.Telephone = txtTelephone.Text;
            currentUser.MyUserInfo.Cellphone = txtCellPhone.Text;

            //instantiate BillingAddress
            currentUser.BillingAddress = new MyUserBillingAddress();

            currentUser.BillingAddress.AddressName = txtBillingAddressName.Text;
            currentUser.BillingAddress.AddressNumber = txtBillingAddressNumber.Text;
            currentUser.BillingAddress.Stair = txtBillingStair.Text;
            currentUser.BillingAddress.Apartment = txtBillingApartment.Text;
            currentUser.BillingAddress.City = txtBillingCity.Text;
            currentUser.BillingAddress.Country = txtBillingCountry.Text;
            currentUser.BillingAddress.Zipcode = txtBillingZipcode.Text;
            
            //instantiate Shipping Address
            currentUser.ShippingAddress = new MyUserShippingAddress();

            currentUser.ShippingAddress.AddressName = txtShippingAddressName.Text;
            currentUser.ShippingAddress.AddressNumber = txtShippingAddressNumber.Text;
            currentUser.ShippingAddress.Stair = txtShippingAddressStair.Text;
            currentUser.ShippingAddress.Apartment = txtShippingAddressApartment.Text;
            currentUser.ShippingAddress.City = txtShippingAddressCity.Text;
            currentUser.ShippingAddress.Country = txtShippingAddressCountry.Text;
            currentUser.ShippingAddress.Zipcode = txtShippingAddressZipcode.Text;

            //instantiate Credit card info
            currentUser.MyUserCCardInfo = new MyUserCCardInfo();

            currentUser.MyUserCCardInfo.CardName = txtCardName.Text;
            currentUser.MyUserCCardInfo.CardNumber = txtCardNumber.Text;
            currentUser.MyUserCCardInfo.CardExpiryDate = txtCardExpiryDate.Text;
            currentUser.MyUserCCardInfo.CardSecurityCode = txtCardSecurityCode.Text;

            ////instantiate Bank info
            //currentUser.MyUserBankInfo = new MyUserBankInfo();
            //currentUser.MyUserBankInfo.BankName = BankName.Text;
            //currentUser.MyUserBankInfo.BankAccountNo = BankAccNumber.Text;
            //currentUser.MyUserBankInfo.BicNo = BankBicNo.Text;
            //currentUser.MyUserBankInfo.BankSwift = BankSwift.Text;


            //Create customer
            Customer customer = new Customer()
            {
                FirstName = currentUser.MyUserInfo.FirstName,
                MiddleName = currentUser.MyUserInfo.MiddleName,
                LastName = currentUser.MyUserInfo.LastName,
                Phone = currentUser.MyUserInfo.Telephone,
                CellPhone = currentUser.MyUserInfo.Cellphone,
                Email = currentUser.MyUserInfo.Email
                //BillingAddress = billingAddress
            };

            //store all
            store.Context.SaveChanges();

            //Finally create the order
            //Create order
            shoppingCart.CreateOrder(currentUser);

            Response.Redirect("~/Secure/UserPagesSecured/ConfirmOrder.aspx");
            }
        }
    }
}