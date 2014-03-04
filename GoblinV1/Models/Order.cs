
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoblinV1.Models
{
    public class Order
    {

        [Key]
        public int OrderNo { get; set; }

        [Required( ErrorMessage=  "No quantity specified")]
        public int Qty { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Created { get; set; }
     

    }
}