using GoblinV1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoblinV1.Logic
{
    internal class RoleActions
    {

        internal void createAdmin()
        {
            // Access the application context and create result variables.
            Models.ApplicationDbContext context = new ApplicationDbContext();

            IdentityResult idTestUserResult;
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;
            IdentityResult idLogisticsResult;
            IdentityResult idProductManagerResult;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            // Then, you create the "Administrator" role if it doesn't already exist.
            if (!roleMgr.RoleExists("Administrator"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole("Administrator"));
                if (!IdRoleResult.Succeeded)
                {
                    // Handle the error condition if there's a problem creating the RoleManager object.
                }
            }


            // Then, you create the "Administrator" role if it doesn't already exist.
            if (!roleMgr.RoleExists("LogisticsManager"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole("LogisticsManager"));
                if (!IdRoleResult.Succeeded)
                {
                    // Handle the error condition if there's a problem creating the RoleManager object.
                }
            }


            // Then, you create the "Administrator" role if it doesn't already exist.
            if (!roleMgr.RoleExists("ProductManager"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole("ProductManager"));
                if (!IdRoleResult.Succeeded)
                {
                    // Handle the error condition if there's a problem creating the RoleManager object.
                }
            }


            // Then, you create the "Administrator" role if it doesn't already exist.
            if (!roleMgr.RoleExists("Customer"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole("Customer"));
                if (!IdRoleResult.Succeeded)
                {
                    // Handle the error condition if there's a problem creating the RoleManager object.
                }
            }

            // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
            // object. Note that you can create new objects and use them as parameters in
            // a single line of code, rather than using multiple lines of code, as you did
            // for the RoleManager object.
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //create admin
            var appUser = new ApplicationUser()
            {
                UserName = "Admin",
                
            };

            //create logistics manager
            var logisticsUser = new ApplicationUser()
            {
                UserName = "LogisticsManager",

            };

            //create product manager
            var productManagerUser = new ApplicationUser()
            {
                UserName = "ProductManager",

            };

            //create test user
            var testUser = new ApplicationUser()
            {
                UserName = "test",

            };


            idTestUserResult = userMgr.Create(appUser, "123456");

            IdUserResult = userMgr.Create(appUser, "123456");

            idLogisticsResult = userMgr.Create(logisticsUser, "123456");

            idProductManagerResult = userMgr.Create(productManagerUser, "123456");

        

            // If the new "Admin" user was successfully created, 
            // add the "Admin" user to the "Administrator" role. 
            if (IdUserResult.Succeeded)
            {
                IdUserResult = userMgr.AddToRole(appUser.Id, "Administrator");

                idLogisticsResult = userMgr.AddToRole(logisticsUser.Id, "LogisticsManager");

                idProductManagerResult = userMgr.AddToRole(productManagerUser.Id, "ProductManager");

                idTestUserResult = userMgr.AddToRole(productManagerUser.Id, "Customer");


                if (!IdUserResult.Succeeded)
                {
                    // Handle the error condition if there's a problem adding the user to the role.
                }
            }
            else
            {
                // Handle the error condition if there's a problem creating the new user. 
            }
        }
    }
}
