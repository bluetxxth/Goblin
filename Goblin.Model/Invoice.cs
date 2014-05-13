using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Goblin.Model
{
    /// Class that represents an invoice
    /// <summary>
    /// </summary>
    public class Invoice
    {


        [Key]
        public int InvoiceNo { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set;}

        public double? SubTotal { get; set; }

        public double Tax { get; set; }

        public double? Total { get; set; }

        public virtual Address BillingAddress { get; set; }


    }
}