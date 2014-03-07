﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoblinV1.Models
{
    public class Order
    {

        
        [Key]
        public int OrderId { get; set; }
        public string Created { get; set; }

        public string Submitted { get; set; }

        public string Processed { get;set; }

        public virtual Address Address { get; set; }

        public List<OrderItem> OrderItems { get; set; }
       
        public int CustomerId { get; set; }

         [ForeignKey("CustomerId")]
        public virtual Customer Customers { get; set; }

         public bool IsProcessed { get; set;}



       

  

    }
}