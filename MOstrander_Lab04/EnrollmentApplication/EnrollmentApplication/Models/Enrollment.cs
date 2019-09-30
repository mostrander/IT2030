using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnrollmentApplication.Models
{
   public class Enrollment
   {

      public virtual int EnrollmentId { get; set; }
      public virtual int StudentId { get; set; }
      public virtual int CourseId { get; set; }

      [Required (ErrorMessage = "Please enter a grade.")]
      [RegularExpression(@"[A - F]", ErrorMessage = "Grade must be A - F.")]
      public virtual String Grade { get; set; }

      public virtual Student Student { get; set; }
      public virtual Course Course { get; set; }
      public virtual Boolean IsActive { get; set; }

      [Required(ErrorMessage = "Please select a campus.")]
      [Display(Name = "Assigned Campus")]
      public virtual string AssignedCampus { get; set; }

      [Required (ErrorMessage = "Please select enrollment semester.")]
      [Display(Name = "Enrolled in Semester")]
      public virtual string EnrollmentSemester { get; set; }

      [Required(ErrorMessage = "Please enter enrollment year.")]
      [Range(2018, 2025, ErrorMessage = "Enrollment year must be between 2018 - 2025.")]
      public virtual int EnrollmentYear { get; set; }

   }
}