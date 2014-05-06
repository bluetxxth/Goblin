using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Goblin.Model
{
    /// <summary>
    /// Class that represents a customer
    /// </summary>
    /// 
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address BillingAddress { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address ShippingAddress { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string CellPhone { get; set; }

        string CreditCardNo { get; set; }

        string BankAccountNo { get; set; }
    }
}