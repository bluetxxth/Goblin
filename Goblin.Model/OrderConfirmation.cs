﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Goblin.Model
{
    public class OrderConfirmation
    {
        public int OrderConfirmationId { get; set; }

        ////Product data
        //public int ProductID { get; set; }

        //[ForeignKey("ProductID")]
        //public Product Product { get; set; }
        //public int OrderId { get; set; }
        //[ForeignKey ("OrderId")]
        public virtual Order Order { get; set; }

        //Customer Data
        public string CustomerName { get; set; }
        public string CustomerMiddle { get; set; }
        public string CustomerLast { get; set; }
        public string CustomerCell { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }

       //Address data
        public string BillingAddressName { get; set; }
        public string BillingAddressNo { get; set; }
        public string BillingApartment { get; set; }
        public string BillingStair { get; set; }
        public string BillingZipCode { get; set; }
        public string BillingCountry { get; set; }
        public string BillingCity { get; set; }

        //Address data
        public string ShippingAddressName { get; set; }
        public string ShippingAddressNo { get; set; }
        public string ShippingApartment { get; set; }
        public string ShippingStair { get; set; }
        public string ShippingZipCode { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingCity { get; set; }


        public string ProductName { get; set; }
        public string ProductSpec { get; set; }
        public double? ProductPrice { get; set; }

        //Payment Data
        public string BankName{get;set;}
        public string BankAccount{get;set;}
        public string BankSwiftCode { get; set; }
        public string BankBicNo { get; set; }
        public string BankRoutingNo { get; set; }

        //CCData
        public string CCardName { get; set; }
        public string CCardNo { get; set; }
        public string CCArdExpiryDate { get; set; }
        public string CCardSecurityCode { get; set; }
        public string Created { get; set; }


        //Totals
        public int Quantity { get; set; }
        public double? Subtotal { get; set; }
        public double? Total { get;set; }
        public virtual Address BillingAddress { get;set; }
        public virtual Address ShippingAddress { get; set; }

        public List<LineItem> LineItems { get; set; }

    }
}