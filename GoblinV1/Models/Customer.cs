using GoblinV1.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoblinV1.Models
{
    /// <summary>
    /// Class that represents a customer
    /// </summary>
    /// 
    public class Customer
    {
        /// <summary>
        /// Creates an object of type Customer
        /// </summary>
        public Customer()
        {

        }

        [Key]
        public int CustomerId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address BillingAddress  { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address ShippingAddress { get; set; }
       
        [ExcludeChar(@"\ ()^[<>.!@#%/]+$123456789")]
        [DisplayName("Customer Name")]
        [StringLength(150)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Customer Name is required xx")]
        [ExcludeChar(@"\ ()^[<>.!@#%/]+$123456789")]
        [DisplayName("Customer Name")]
        [StringLength(150)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Customer Middle Name is required xx")]
        [ExcludeChar(@"\ ()^[<>.!@#%/]+$123456789")]
        [DisplayName("Middle")]
        [StringLength(150)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Customer Last Name is required xx")]
        [ExcludeChar(@"\ ()^[<>.!@#%/]+$123456789")]
        [DisplayName("Last")]
        public string LastName { get; set; }
        [StringLength(150)]

        [Required(ErrorMessage = "Email Address is required xx")]
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        ErrorMessage = "Email is is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telephone is required xx")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        [DisplayName("Telephone")]
        public string Phone { get; set; }

        public string CellPhone { get; set; }

        //accepting only visa according to this http://www.regular-expressions.info/creditcard.html
        [Required(ErrorMessage = "CC No is Required")]
        [RegularExpression("^(?:4[0-9]{12}(?:[0-9]{3})?")]
        [DisplayName("Credit Card No.")]
        string CreditCardNo { get; set; }

        [Required(ErrorMessage = "Bank Account Required")]
        [DisplayName("Bank Acc.")]
        string BankAccountNo { get; set; }
    }
}