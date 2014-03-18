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
        private int m_zipcode = 0;
        private int m_streetNumber = 0;
        private string m_streetName = null;
        private string m_city = null;
        private string m_Country = null;


        public Address()
        {

        }

        /// <summary>
        /// Proviudes accessor and mutator
        /// </summary>
        public Address(int zipCode, int streetNumber, string streetName, string city, string country)
        {
            this.m_zipcode = zipCode;
            this.m_streetName = streetName;
            this.m_streetNumber = streetNumber;
            this.m_city = city;
            this.m_Country = country;
        }

        [Key]
        public virtual int AddressId { get; set; }


        [Required(ErrorMessage = "Address Name is required")]
        [DisplayName("Address Name")]
        [StringLength(150)]
        public string StreetName { get; set; }

        //public int CustomerId { get; set; }

        //[ForeignKey("CustomerId")]
        //public Customer Customer { get; set; }

        [Required(ErrorMessage = "Street No. is required")]
        [DisplayName("AStreet No.")]
        public string StreetNo { get; set; }

        [Required(ErrorMessage = "City Name is required")]
        [DisplayName("City Name")]
        [StringLength(150)]
        public string City { get; set; }

        [Required(ErrorMessage = "Country Name is required")]
        [DisplayName("Country Name")]
        [StringLength(150)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Zipcode  is required")]
        [DisplayName("Zipcode")]
        public string ZipCode { get; set; }

    }
}