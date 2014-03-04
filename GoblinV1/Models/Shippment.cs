using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoblinV1.Models
{
    public class Shippment
    {
        [Key]
        public int ShipmentId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string State { get; set; }
        public virtual Order Order { get; set; }
        public virtual Address DeliveryAddress { get; set; }

    }
}