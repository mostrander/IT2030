using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IT2030_MeganOstrander_FinalProject.Models
{
   public class Event
   {
      [Required]
      [StringLength(50, MinimumLength = 3)]
      public String Title { get; set; }

      public virtual EventType Type { get; set; }

      [Required]
      public DateTime StartDate { get; set; }

      [Required]
      public DateTime StartTime { get; set; }

      [Required]
      public DateTime EndDate { get; set; }

      [Required]
      public DateTime EndTime { get; set; }

      [Required]
      public String Location { get; set; }

      [Required]
      public virtual Organizer OrganizerName {get;set;} 

      [StringLength(150)]
      public String Description { get; set; }

      [Required]
      [Range(1, 100)]
      public int MaxTickets { get; set; }
      public int AvailableTickets { get; set; }

   }

}