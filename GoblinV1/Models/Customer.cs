using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoblinV1.Models
{
    /// <summary>
    /// Class that represents a customer
    /// </summary>
    public class Customer
    {
        private int m_id = 0;
        private int m_phoneNumber = 0;
        private int m_creditCardNumber = 0;
        private int m_bankAccountNumber = 0;
        private string m_firstName = null;
        private string m_middleName = null;
        private string m_lastName = null;
        private string m_emailAddress = null;
        private Address m_address = null;



        /// <summary>
        /// Creates an object of type Customer
        /// </summary>
        public Customer()
        {

        }

        /// <summary>
        /// Creates an object of class customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="zipCode"></param>
        /// <param name="streetNumber"></param>
        /// <param name="firstName"></param>
        /// <param name="midleName"></param>
        /// <param name="lastName"></param>
        /// <param name="streetName"></param>
        /// <param name="city"></param>
        /// <param name="country"></param>
        /// <param name="emailAddress"></param>
        /// <param name="creditCardNumber"></param>
        public Customer(int id, int phoneNumber, string firstName,
                        string midleName, string lastName, string streetName,
                        string emailAddress, int creditCardNumber)
        {

            this.m_id = id;
            this.m_phoneNumber = phoneNumber;
            this.m_firstName = firstName;
            this.m_middleName = midleName;
            this.m_lastName = lastName;
            this.m_emailAddress = emailAddress;
            this.m_address = new Address();
        }


        public int CustomerId { get; set; }

        public Order Order { get; set;}

        public virtual Address Address { get; set; }


        public string FirstName { get; set; }


        public string MiddleName { get; set; }


        public string LastName { get; set; }


        public string Email { get; set; }


        public int Phone { get; set; }


        int CreditCardNo { get; set; }


        int BankAccountNo { get; set; }
    }
}