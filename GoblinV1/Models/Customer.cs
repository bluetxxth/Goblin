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

        /// <summary>
        /// Provides accessor and mutator
        /// </summary>
        public int ID
        {
            get { return m_id; }
            set { m_id = value; }
        }

        /// <summary>
        /// Collectoin of products
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }


        /// <summary>
        /// Provides accessor and mutator
        /// </summary>
        public string FirstName
        {
            get { return m_firstName; }
            set { m_firstName = value; }
        }

        /// <summary>
        /// Provides accessor and mutator
        /// </summary>
        public string MiddleName
        {
            get { return m_middleName; }
            set { m_middleName = value; }
        }

        /// <summary>
        /// Provides accessor and mutator
        /// </summary>
        public string LastName
        {
            get { return m_lastName; }
            set { m_lastName = value; }
        }

        /// <summary>
        /// Provides accessor and mutator 
        /// </summary>
        public virtual Address Address
        {
            get { return m_address; }
            set { m_address = value; }
        }

        /// <summary>
        /// Provides accessor and mutator
        /// </summary>
        public string Email
        {
            get { return m_emailAddress; }
            set { m_emailAddress = value; }
        }

        /// <summary>
        /// Provides accessor and mutator
        /// </summary>
        public int Phone
        {
            get { return m_phoneNumber; }
            set { m_phoneNumber = value; }
        }

        /// <summary>
        /// Provides accessor and mutator
        /// </summary>
        int CreditCardNo
        {
            get { return m_creditCardNumber; }
            set { m_creditCardNumber = value; }
        }

        /// <summary>
        /// Provides accessor and mutator
        /// </summary>
        int BankAccountNo
        {
            get { return m_bankAccountNumber; }
            set { m_bankAccountNumber = value; }
        }
    }
}