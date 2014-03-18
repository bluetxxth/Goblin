using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoblinV1.Logic
{
    /// <summary>
    /// class for custom data annotation
    /// </summary>
    public class ExcludeChar : ValidationAttribute
    {
        private readonly string m_chars;

        public ExcludeChar(string chars): base("{0} contains invalid character.")
        {
            this.m_chars = chars;
        }


        /// <summary>
        /// Search for invalid characters and return error if some found otherwise success
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns> ValidationResultError or succes depending if invlaid characters found</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext){

            if(value != null)
            {
                for (int i = 0; i < m_chars.Length; i++)
                {
                    var valueAsString = value.ToString();
                    if (valueAsString.Contains(m_chars[i]))
                    {
                        var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                        return new ValidationResult(errorMessage);
                    }
                }
            }

            return ValidationResult.Success;
        }

    }
}