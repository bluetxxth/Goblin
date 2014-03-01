
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoblinV1.Models
{
    public class Order
    {

        public int OrderNo { get; set; }
        public int Qty { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}