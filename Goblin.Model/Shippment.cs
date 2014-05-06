using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Goblin.Model
{
    public class Shippment
    {
        [Key]
        public int ShipmentId { get; set; }
        public string ShippedOn { get; set; }
        public bool IsSent { get; set; }
        public string State { get; set; }
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        public string AddresName { get; set; }
        public string AddressNo{get; set;}
        public string AddresStair{get; set;}
        public string AddresApt { get; set;}
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        //public int AddressId { get; set; }

        //[ForeignKey("AddressId")]
        //public Address ShippingAddress { get; set; }

        //public virtual Address ShippingAddress { get; set; }






    }
}