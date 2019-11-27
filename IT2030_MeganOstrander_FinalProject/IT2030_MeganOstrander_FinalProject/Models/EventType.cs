using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IT2030_MeganOstrander_FinalProject.Models
{
   public class EventType
   {
      
      public int EventId { get; set; }

      [Required]
      [StringLength(50, MinimumLength = 3)]
      public String Name { get; set; }

      public String Description { get; set; }

   }
}