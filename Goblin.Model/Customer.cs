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
        public virtual Address BillingAddress  { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address ShippingAddress { get; set; }

        
        [RegularExpression(@"[^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$",
        ErrorMessage = "User name is is not valid.")]
        [DisplayName("User Name")]
        [StringLength(150)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Customer First Name is required")]
        [RegularExpression(@"[^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$",
        ErrorMessage = "Customer name is is not valid.")]
        [DisplayName("Customer Name")]
        [StringLength(150)]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Customer middle Name is required")]
        [RegularExpression(@"[^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$",
        ErrorMessage = "Customer middle name is is not valid.")]
        [DisplayName("Middle")]
        [StringLength(150)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Customer last name is required")]
        [RegularExpression(@"[^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$",
        ErrorMessage = "Customer last name is is not valid.")]
        [DisplayName("Last")]
        public string LastName { get; set; }
        [StringLength(150)]

        [Required(ErrorMessage = "Email Address is required xx")]
        [DisplayName("Email Address")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
        ErrorMessage = "Email is is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telephone is required")]
        [RegularExpression(@"^(1?(-?\d{3})-?)?(\d{3})(-?\d{4})$", ErrorMessage = "Entered phone format is not valid.")]
        [DisplayName("Telephone")]
        public string Phone { get; set; }

        public string CellPhone { get; set; }

        //accepting only visa according to this http://www.regular-expressions.info/creditcard.html
        [Required(ErrorMessage = "CC No is Required")]
        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|6(?:011|5[0-9]{2})[0-9]{12}|(?:2131|1800|35\d{3})\d{11}#JCB)$")]
        [DisplayName("Credit Card No.")]
        string CreditCardNo { get; set; }

        [Required(ErrorMessage = "Bank Account Required")]
        [DisplayName("Bank Acc.")]
        string BankAccountNo { get; set; }
    }
}