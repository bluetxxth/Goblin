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
                HttpContext.Current.Response.Redirect("/Account/Login.aspx");
            }

           
            //instantiate MyUserInfo
            currentUser.MyUserInfo = new MyUserInfo();

            currentUser.MyUserInfo.FirstName = FirstName.Text;
            currentUser.MyUserInfo.MiddleName = MiddleName.Text;
            currentUser.MyUserInfo.LastName = LastName.Text;
            currentUser.MyUserInfo.Email = Email.Text;
            currentUser.MyUserInfo.Telephone = Telephone.Text;
            currentUser.MyUserInfo.Cellphone = CellPhone.Text;

            //instantiate BillingAddress
            currentUser.BillingAddress = new MyUserBillingAddress();

            currentUser.BillingAddress.AddressName = BillingAddressName.Text;
            currentUser.BillingAddress.AddressNumber = BillingAddressNumber.Text;
            currentUser.BillingAddress.Stair = BillingStair.Text;
            currentUser.BillingAddress.Apartment = BillingApartment.Text;
            currentUser.BillingAddress.City = BillingCity.Text;
            currentUser.BillingAddress.Country = BillingCountry.Text;
            currentUser.BillingAddress.Zipcode = BillingZipcode.Text;
            

            //instantiate Shipping Address
            currentUser.ShippingAddress = new MyUserShippingAddress();

            currentUser.ShippingAddress.AddressName = ShippingAddressName.Text;
            currentUser.ShippingAddress.AddressNumber = ShippingAddressNumber.Text;
            currentUser.ShippingAddress.Stair = ShippingAddressStair.Text;
            currentUser.ShippingAddress.Apartment = ShippingAddressApartment.Text;
            currentUser.ShippingAddress.City = ShippingAddressCity.Text;
            currentUser.ShippingAddress.Country = ShippingAddressCountry.Text;
            currentUser.ShippingAddress.Zipcode = ShippingAddressZipcode.Text;


            //instantiate Credit card info
            currentUser.MyUserCCardInfo = new MyUserCCardInfo();

            currentUser.MyUserCCardInfo.CardName = CardName.Text;
            currentUser.MyUserCCardInfo.CardNumber = CardName.Text;
            currentUser.MyUserCCardInfo.CardExpiryDate = CardExpiryDate.Text;
            currentUser.MyUserCCardInfo.CardSecurityCode = CardSecurityCode.Text;

            ////instantiate Bank info
            //currentUser.MyUserBankInfo = new MyUserBankInfo();

            //currentUser.MyUserBankInfo.BankName = BankName.Text;
            //currentUser.MyUserBankInfo.BankAccountNo = BankAccNumber.Text;
            //currentUser.MyUserBankInfo.BicNo = BankBicNo.Text;
            //currentUser.MyUserBankInfo.BankSwift = BankSwift.Text;


            //store all
    
            store.Context.SaveChanges();

            //Finally create the order
            //Create order
            shoppingCart.CreateOrder(currentUser);

         
            HttpContext.Current.Response.Redirect("/Secure/UserPagesSecured/ConfirmOrder.aspx");

        }
    }
}