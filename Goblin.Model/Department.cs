using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Goblin.Model
{
    public class Department
    {

         [ScaffoldColumn(false)]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set;}
        public string DepartmentIcon { get; set; }
        public string DepartmentUrl { get; set; }
        public string DepartmentDescription { get; set; }
        public string DepartmentAdmin { get; set; }
    }
}