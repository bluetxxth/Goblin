﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Goblin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToLongTimeString();
        }



    }
}