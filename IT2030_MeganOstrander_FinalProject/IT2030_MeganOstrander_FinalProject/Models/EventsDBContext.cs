using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

//REMEMBER: Database will not appear until the program is ran for the first time after creating the context!

namespace IT2030_MeganOstrander_FinalProject.Models
{
    public class EventsDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EventsDBContext() : base("name=EventsDBContext")
        {
        }

      public System.Data.Entity.DbSet<IT2030_MeganOstrander_FinalProject.Models.Event> Events { get; set; }

      public System.Data.Entity.DbSet<IT2030_MeganOstrander_FinalProject.Models.Organizer> Organizers { get; set; }

      public System.Data.Entity.DbSet<IT2030_MeganOstrander_FinalProject.Models.Type> Types { get; set; }

      public System.Data.Entity.DbSet<IT2030_MeganOstrander_FinalProject.Models.Cart> Carts { get; set; }
   }
}
