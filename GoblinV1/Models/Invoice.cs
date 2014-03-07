using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoblinV1.Models
{
    /// Class that represents an invoice
    /// <summary>
    /// </summary>
    public class Invoice
    {

        private int m_invoiceNo = 0;
        private double m_subTotal = 0.0;
        private double m_taxRate = 0.0;
        private double m_total = 0.0;

        /// <summary>
        /// Creates object of type invoice
        /// </summary>
        public Invoice()
        {

        }

        /// <summary>
        /// Creates object of type invoice
        /// </summary>
        /// <param name="invoiceNo"></param>
        /// <param name="subTotal"></param>
        /// <param name="taxRate"></param>
        /// <param name="total"></param>
        public Invoice(int invoiceNo, double subTotal, double taxRate, double total)
        {
            this.m_invoiceNo = invoiceNo;
            this.m_subTotal = subTotal;
            this.m_taxRate = taxRate;
            this.m_total = total;
        }

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