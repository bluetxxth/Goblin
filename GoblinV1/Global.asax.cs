﻿using GoblinV1.Logic;
using GoblinV1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace GoblinV1
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
             //new EntityMappingContext().Products.ToList();
           
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //Initialize the identity database
           // Database.SetInitializer(new IdentityDBInitializer());

            // Create the administrator role and user.
            RoleActions roleActions = new RoleActions();
            roleActions.createAdmin();

            // Initialize the product database.
            Database.SetInitializer(new DataBaseInitializer());

        }
    }
}