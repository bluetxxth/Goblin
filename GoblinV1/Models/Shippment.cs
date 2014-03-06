using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        public virtual Address DeliveryAddress { get; set; }

        public virtual Address BillingAddress { get; set; }

        //public int AddressId { get; set; }

        //[ForeignKey("AddressId")]
        //public Address Address { get; set; }




    }
}