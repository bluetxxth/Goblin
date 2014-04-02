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

    public class Address
    {

        [Key]
        public virtual int AddressId { get; set; }


        [Required(ErrorMessage = "Address Name is required")]
        [ExcludeChar(@"\ ()^[<>.!@#%/]+$123456789")]
        [DisplayName("Address Name")]
        [StringLength(150)]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Street No. is required")]
        [ExcludeChar(@" ^[<>.!@#%]+$")]
        [DisplayName("AStreet No.")]
        public string StreetNo { get; set; }


        public string Apartment { get; set; }
        public string Stair { get; set; }


        [Required(ErrorMessage = "City Name is required")]
        [ExcludeChar(@"\ ()^[<>.!@#%/]+$123456789")]
        [DisplayName("City Name")]
        [StringLength(150)]
        public string City { get; set; }

        [Required(ErrorMessage = "Country Name is required")]
        [ExcludeChar(@"\ ()^[<>.!@#%/]+$123456789")]
        [DisplayName("Country Name")]
        [StringLength(150)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Zipcode  is required")]
        [ExcludeChar(@"\ ()^[<>.!@#%/]+$")]
        [DisplayName("Zipcode")]
        public string ZipCode { get; set; }

    }
}