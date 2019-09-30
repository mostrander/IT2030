using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnrollmentApplication.Models
{
   public class Student
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

   }
}