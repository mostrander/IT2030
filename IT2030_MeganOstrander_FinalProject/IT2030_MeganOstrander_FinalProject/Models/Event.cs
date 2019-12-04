using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IT2030_MeganOstrander_FinalProject.Models
{
   public class Event
   {

      public virtual int EventId { get; set; }
      public virtual int TypeId { get; set; }
      public virtual int OrganizerId { get; set; }

      [Required]
      [StringLength(50, MinimumLength = 3)]
      public virtual String Title { get; set; }

      public virtual Type Type { get; set; }

      [Required]
      public virtual DateTime StartDate { get; set; }

      [Required]
      public virtual DateTime StartTime { get; set; }

      [Required]
      public virtual DateTime EndDate { get; set; }

      [Required]
      public virtual DateTime EndTime { get; set; }

      [Required]
      public virtual String Location { get; set; }

      [Required]
      public virtual String City { get; set; }

      [Required]
      public virtual String State { get; set; }

      [Required]
      public virtual Organizer Organizer {get;set;} 

      [StringLength(150)]
      public virtual String Description { get; set; }

      [Required]
      [Range(1, 100)]
      public virtual int MaxTickets { get; set; }
      public virtual int AvailableTickets { get; set; }

     
      public virtual int Quantity { get; set; }
   }
   
}