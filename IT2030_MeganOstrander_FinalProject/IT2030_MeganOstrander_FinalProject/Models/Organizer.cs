using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IT2030_MeganOstrander_FinalProject.Models
{
   public class Organizer
   {
      [Key]
      public virtual int OrganizerId { get; set; }

      [Required]
      public virtual String Name { get; set; }

      public virtual String ContactInfo { get; set; }

   }
}