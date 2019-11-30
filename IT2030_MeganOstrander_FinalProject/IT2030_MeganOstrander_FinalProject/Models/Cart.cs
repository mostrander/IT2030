using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT2030_MeganOstrander_FinalProject.Models
{
   public class Cart
   {
      //Primary key for the carts, UNIQUE
      [Key]
      public int RecordId { get; set; }

      //ID that takes name from user login information to identigy who is registering for events
      public String OrderId { get; set;}

      public int EventId { get; set; }

      //virtual does not add column to tables/databases!
      public virtual Event EventSelected { get; set; }

      public int Quantity { get; set; }

      public DateTime DateOrdered { get; set; }
   }
}