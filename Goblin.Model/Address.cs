
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Goblin.Model
{

    public class Address
    {

        [Key]
        public virtual int AddressId { get; set; }

        
        [Required(ErrorMessage = "Address Name is required")]
        [RegularExpression(@"^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$", ErrorMessage = "Address  Name is not valid.")]
        [DisplayName("Address Name")]
        [StringLength(150)]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Street No. is required")]
        [RegularExpression(@"^[a-zA-Z0-9]{1,10}$", ErrorMessage = "Address  No not valid.")]
        [DisplayName("AStreet No.")]
        public string StreetNo { get; set; }

        public string Apartment { get; set; }
        public string Stair { get; set; }


        [Required(ErrorMessage = "City Name is required")]
        [RegularExpression(@"^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$", ErrorMessage = "City  No not valid.")]
        [DisplayName("City Name")]
        [StringLength(150)]
        public string City { get; set; }

        [Required(ErrorMessage = "Country Name is required")]
        [RegularExpression(@"^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$", ErrorMessage = "Country  No not valid.")]
        [DisplayName("Country Name")]
        [StringLength(150)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Zipcode  is required")]
        [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Zipcode  No not valid.")]

        [DisplayName("Zipcode")]
        public string ZipCode { get; set; }

    }
}