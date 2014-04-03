using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Web;
using System;
using GoblinV1.Models;

namespace GoblinV1.Models
{
    // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual MyUserInfo MyUserInfo { get; set; }
        public virtual MyUserBillingAddress BillingAddress { get; set; }
        public virtual MyUserShippingAddress ShippingAddress { get; set; }
        //public virtual MyUserBankInfo MyUserBankInfo { get; set; }
        public virtual MyUserCCardInfo MyUserCCardInfo { get; set; }
    }


    /// <summary>
    /// User's  information
    /// </summary>
    public class MyUserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }

    }

    /// <summary>
    /// User's  billing Address
    /// </summary>
    public class MyUserBillingAddress
    {
        public int Id { get; set; }
        public string AddressName { get; set; }
        public string AddressNumber { get; set; }
        public string Stair { get; set; }
        public string Apartment { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
    }


    /// <summary>
    /// User's  Delivery Address
    /// </summary>
    public class MyUserShippingAddress
    {
        public int Id { get; set; }
        public string AddressName { get; set; }
        public string AddressNumber { get; set; }
        public string Stair { get; set; }
        public string Apartment { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
    }



    /// <summary>
    /// User Credit card information
    /// </summary>
    public class MyUserCCardInfo
    {
        public int Id { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiryDate { get; set; }
        public string CardSecurityCode { get; set;}

    }

    ///// <summary>
    ///// User Bank Information
    ///// </summary>
    //public class MyUserBankInfo
    //{
    //    public int Id { get; set; }
    //    public string BankName { get; set; }
    //    public string BankAccountNo { get; set; }
    //    public string BicNo { get; set; }
    //    public string BankSwift{get;set;}
       
    //}

    /// <summary>
    /// INitialize Application context 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        //the entity user info
        public System.Data.Entity.DbSet<MyUserInfo> MyUserInfo { get; set; }
        public System.Data.Entity.DbSet<MyUserBillingAddress> BillingAddress { get; set; }
        public System.Data.Entity.DbSet<MyUserShippingAddress> ShippingAddress { get; set; }
        public System.Data.Entity.DbSet<MyUserCCardInfo> MyUserCCardInfo { get; set; }
        //public System.Data.Entity.DbSet<MyUserBankInfo> MyUserBankInfo { get; set; }
    }

    #region Helpers
    public class UserManager : UserManager<ApplicationUser>
    {
        public UserManager()
            : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {
        }
    }
}

namespace GoblinV1
{
    public static class IdentityHelper
    {
        // Used for XSRF when linking external logins
        public const string XsrfKey = "XsrfId";

        public static void SignIn(UserManager manager, ApplicationUser user, bool isPersistent)
        {
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public const string ProviderNameKey = "providerName";
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request[ProviderNameKey];
        }

        public static string GetExternalLoginRedirectUrl(string accountProvider)
        {
            return "/Account/RegisterExternalLogin?" + ProviderNameKey + "=" + accountProvider;
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
    #endregion
}