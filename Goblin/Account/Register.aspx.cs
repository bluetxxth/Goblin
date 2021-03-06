﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.Owin.Security;
using Goblin.BLL;
using System.Data.Entity.Core;
using Goblin.Model;

namespace Goblin.Account
{
    public partial class Register : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            // var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager();
            var user = new ApplicationUser() { UserName = UserName.Text };

            try
            {
                IdentityResult result = userManager.Create(user, Password.Text);

                RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(
                 new RoleStore<IdentityRole>(new ApplicationDbContext()));

                if (result.Succeeded)
                {

                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    //create a user role
                    CreateRole("Customer");

                    var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                    store.AutoSaveChanges = false;
                    var currentUserId = User.Identity.GetUserId();
                    var manager = new UserManager<ApplicationUser>(store);
                    var currentUser = manager.FindById(User.Identity.GetUserId());


                    //get current user
                    //var currentUser = userManager.FindByName(user.UserName);

                    StatusMessage.Text = string.Format("User {0} was created successfully!", user.UserName);
                    IdentityHelper.SignIn(userManager, user, isPersistent: false);

                    //migrate shopping cart 
                    using (ShoppingCartEngine usersShoppingCart = new ShoppingCartEngine())
                    {
                        //get the GUID and assign to cardId
                        String cartId = usersShoppingCart.GetCartId();

                        //pass cartId and User id to migrateCart method
                        usersShoppingCart.MigrateCart(cartId, user.Id);
                    }

                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);


                    //Add user to role
                    var roleresult = userManager.AddToRole(currentUser.Id, "Customer");

                    if (!roleManager.RoleExists("Customer"))
                    {
                        Session["Error"] = "Role does not exist";

                        Response.Redirect("/UserPages/ErrorPage.aspx");
                    }

                    if (!System.Web.HttpContext.Current.User.IsInRole("Customer"))
                    {

                        Session["Error"] = "user is not in role";

                        Response.Redirect("/UserPages/ErrorPage.aspx");
                    }

                    authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                    Response.Redirect("~/Login.aspx");
                }
                else
                {
                    ErrorMessage.Text = result.Errors.FirstOrDefault();
                }
            }
            catch (EntityCommandExecutionException ex)
            {
                Session["Error"] = ex;
                Response.Redirect("/UserPages/ErrorPage.aspx");
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