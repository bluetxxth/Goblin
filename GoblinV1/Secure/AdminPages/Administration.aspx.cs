﻿using GoblinV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoblinV1.Secure.AdminPages
{
    public partial class Administration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


        public IQueryable<Department> GetDepartments([QueryString("id")] int? departmentId)
        {
            var ctx = new EntityMappingContext();
            IQueryable<Department> query = ctx.Departments;
            if (departmentId.HasValue && departmentId > 0)
            {
                query = query.Where(dep => dep.DepartmentId == departmentId);
            }
            return query;
        }
    }
}