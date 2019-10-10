using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
   public class InvalidCharsAttribute : ValidationAttribute
   {

      readonly string value;

      public InvalidCharsAttribute(string value) :base("{0} contains unacceptable characters!")
      {
         this.value = value;
      }

      protected override ValidationResult IsValid(object value, ValidationContext validationContext)
      {
         if(value != null)
         {
            if(value.Equals("*") || value.Equals("<") || value.Equals(">") || value.Equals("{") || value.Equals("}"))
            {
               var ErrorMessage = FormatErrorMessage(validationContext.DisplayName);
               return new ValidationResult(ErrorMessage);
            }

         }


         return ValidationResult.Success;
         //return base.IsValid(value, validationContext);
      }



   }
}