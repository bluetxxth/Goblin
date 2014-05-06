using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Goblin.Model
{
    public class IdentityMappingContext : IdentityDbContext<MyUser>
    {

        public IdentityMappingContext() : base("DefaultConnection") { }


        //the entity user info
        public System.Data.Entity.DbSet<MyUserInfo> MyUserInfo { get; set; }

    }
}