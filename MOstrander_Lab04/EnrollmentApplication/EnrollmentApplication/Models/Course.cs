using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnrollmentApplication.Models
{
   public class Course
   {
      [Display(Name = "Course ID")]
      public virtual int CourseId { get; set; }

      [Required(ErrorMessage = "Please enter course title.")]
      [StringLength(150, ErrorMessage = "Course title is too long.")]
      [Display(Name = "Course Title")]
      public virtual string CourseTitle { get; set; }

      [Display(Name = "Description")]
      public virtual string CourseDescription { get; set; }

      [Required(ErrorMessage = "Please enter number of credits.")]
      [Display(Name = "Number of credits")]
      [Range(1,4, ErrorMessage = "Credits must be between 1 - 4.")]
      public virtual int CourseCredits { get; set; }

   }
}