using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IT2030_MeganOstrander_FinalProject.Models
{
   public class Type
   {
      [Key]
      public virtual int TypeId { get; set; }

      //[Required]
      //[StringLength(50, MinimumLength = 3)]
      public virtual String Name { get; set; }

      public virtual String Description { get; set; }

   }
}