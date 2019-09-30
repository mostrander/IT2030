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

      [Required]
      [StringLength(150)]
      [Display(Name = "Course Title")]
      public virtual string CourseTitle { get; set; }

      [Display(Name = "Description")]
      public virtual string CourseDescription { get; set; }

      [Required]
      [Display(Name = "Number of credits")]
      [Range(1,4)]
      public virtual int CourseCredits { get; set; }

   }
}