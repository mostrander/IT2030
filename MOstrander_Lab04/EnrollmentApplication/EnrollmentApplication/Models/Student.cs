using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnrollmentApplication.Models
{
   public class Student: IValidatableObject
   {
      [Display(Name = "Student ID")]
      public virtual int StudentId { get; set; }

      [Required(ErrorMessage = "Please enter last name.")]
      [StringLength(50, ErrorMessage = "Last name is too long. Max length is 50 characters.")]
      [Display(Name = "Last Name")]
      public virtual string LastName { get; set; }

      [Required(ErrorMessage = "Please enter first name")]
      [StringLength(50, ErrorMessage = "First name is too long. Max length is 50 characters.")]
      [Display(Name = "First Name")]
      public virtual string FirstName { get; set; }


      //Lab 7 additions
      public virtual string Address1 { get; set; }
      public virtual string Address2 { get; set; }
      public virtual string City { get; set; }
      public virtual string Zipcode { get; set; }
      public virtual string State { get; set; }

      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
         //validate zipcode is 5 digits
         if (Zipcode.Length != 5)
         {
            yield return (new ValidationResult("Please enter a 5 digit Zipcode."));
         }

         //validate state is 2 digits
         if(State.Length > 2)
         {
            yield return (new ValidationResult("Please enter a 2 digit State code."));
         }

         //check address 1 != address2
         if (Address1.Equals(Address2))
         {
            yield return (new ValidationResult("Address 2 cannot be the same as Address 1."));
         }


         //throw new NotImplementedException();
      }
   }
}