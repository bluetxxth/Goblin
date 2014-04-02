using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoblinV1.Models
{
    public class IdentityDBInitializer : DropCreateDatabaseIfModelChanges<IdentityDbContext>
    {

        protected override void Seed(IdentityDbContext idbctx)
        {
            var UserManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(idbctx));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(idbctx));

            string name = "Admin";
            string password = "123456";
            string test = "Admin";

            //Create Role Test and User Test
            RoleManager.Create(new IdentityRole(test));
            UserManager.Create(new IdentityUser() { UserName = test });

            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(name))
            {
                var roleresult = RoleManager.Create(new IdentityRole(name));
            }

            //Create User=Admin with password=123456
            var user = new IdentityUser();
            user.UserName = name;
            var adminresult = UserManager.Create(user, password);

            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, name);
            }
            base.Seed(idbctx);
        }
    }
}