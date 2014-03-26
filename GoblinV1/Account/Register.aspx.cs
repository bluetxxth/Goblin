using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using GoblinV1.Models;
using Microsoft.Owin.Security;
using GoblinV1.Logic;
using System.Web.Security;

namespace GoblinV1.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var userManager = new UserManager();
            var user = new ApplicationUser() { UserName = UserName.Text };
            IdentityResult result = userManager.Create(user, Password.Text);

            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(
               new RoleStore<IdentityRole>(new ApplicationDbContext()));

            if (result.Succeeded)
            {

                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //add user to customer role 
                //Roles.AddUserToRole(User.Identity.Name , "Customer");

                //create a user role
                CreateRole("Customer");

                //get current user
                var currentUser = userManager.FindByName(user.UserName);

                //Add user to role
                var roleresult = userManager.AddToRole(currentUser.Id, "Customer");


                ////Add user to role
                //userManager.AddToRole(user.Id, "Customer");

                if(!roleManager.RoleExists("Customer"))
                {
                    Session["Error"] = "Role does not exist";

                    Response.Redirect("/UserPages/ErrorPage.aspx");
                }

                if(!userManager.IsInRole(user.Id, "Customer")){

                    Session["Error"] = "user is not in role";

                    Response.Redirect("/UserPages/ErrorPage.aspx");
                }
                //else
                //{

                //    Session["Error"] = "user is added to the role";

                //    Response.Redirect("/UserPages/ErrorPage.aspx");
                //}
                

                //if (System.Web.HttpContext.Current.User.IsInRole("Customer"))
                //{
                //    //check if the user has entered his personal data if not send him to the page where he can do so
                //    Session["Error"] = System.Web.HttpContext.Current.User.Identity.Name;

                //    Response.Redirect("/UserPages/ErrorPage.aspx");
                //}
                //else
                //{
                //    Session["Error"] = "user is not in any role";

                //    Response.Redirect("/UserPages/ErrorPage.aspx");
                //}

                StatusMessage.Text = string.Format("User {0} was created successfully!", user.UserName);
                IdentityHelper.SignIn(userManager, user, isPersistent: false);


                //migrate shopping cart 
                using (ShoppingCartEngine usersShoppingCart = new ShoppingCartEngine())
                {
                    String cartId = usersShoppingCart.GetCartId();
                    usersShoppingCart.MigrateCart(cartId, user.Id);
                }


                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                Response.Redirect("~/Login.aspx");

            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }


        }

        public bool CreateRole(string name)
        {

            // Swap ApplicationRole for IdentityRole:
            RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));

            // Swap ApplicationRole for IdentityRole:
            var idResult = _roleManager.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }
    }
}