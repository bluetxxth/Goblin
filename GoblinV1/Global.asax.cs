﻿using GoblinV1.Models;
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
           //new Models.EntityMappingContext().Products.ToList();
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize the product database.
           Database.SetInitializer(new DataBaseInitializer());
           Database.SetInitializer(new IdentityDBInitializer());
        }
    }
}