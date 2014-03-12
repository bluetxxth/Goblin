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

        [Required(ErrorMessage = "Customer Name is required")]
        [DisplayName("Customer Name")]
        [StringLength(150)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Customer Middle Name is required")]
        [DisplayName("Middle")]
        [StringLength(150)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Customer Last Name is required")]
        [DisplayName("Last")]
        [StringLength(150)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]
         [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        ErrorMessage = "Email is is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telephone is required")]
        [DisplayName("Telephone")]
        public int Phone { get; set; }

        [Required(ErrorMessage = "CC No is Required")]
        [DisplayName("Credit Card No.")]
        int CreditCardNo { get; set; }

        [Required(ErrorMessage = "Bank Account Required")]
        [DisplayName("Bank Acc.")]
        int BankAccountNo { get; set; }
    }
}