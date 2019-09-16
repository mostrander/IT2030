using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnrollmentApplication.Models
{
   public class Enrollment
   {

      public virtual int EnrollmentId { get; set; }
      public virtual Student StudentId { get; set; }
      public virtual Course CourseId { get; set; }
      public virtual int Grade { get; set; }
      public virtual Student Student { get; set; }
      public virtual Course Course { get; set; }

   }
}