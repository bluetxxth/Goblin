using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoblinV1.Models
{
    public class OrderStatus
    {

        [Key]
        public int OrderStatusId { get; set; }
        public string Status { get; set; }
        public bool Processed { get; set; }
    }
}