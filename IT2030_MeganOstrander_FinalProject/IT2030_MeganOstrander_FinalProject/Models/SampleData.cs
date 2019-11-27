using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IT2030_MeganOstrander_FinalProject.Models
{
   public class SampleData : DropCreateDatabaseIfModelChanges<EventsDBContext>
   {
      protected override void Seed(EventsDBContext context)
      {
         var organizers = new List<Organizer>
            {
                new Organizer { Name = "Molly Whitmen", ContactInfo = "" },
                new Organizer { Name = "Tony Stark", ContactInfo = ""  },
                new Organizer { Name = "Jessica Simpson", ContactInfo = ""  },
                new Organizer { Name = "Usagi Tsukino", ContactInfo = ""  },
                new Organizer { Name = "Mercer Frey", ContactInfo = ""  },
                new Organizer { Name = "Annabell", ContactInfo = ""  }
            };

         var type = new List<Type>
            {
               new Type { Name = "Singles", Description = "" },
               new Type { Name = "Couples", Description = "" },
               new Type { Name = "Seminar", Description = "" },
               new Type { Name = "Expo", Description = "" },
               new Type { Name = "Concert", Description = "" },
               new Type { Name = "Gala", Description = "" },
               new Type { Name = "Fundraiser", Description = "" },
               new Type { Name = "Child Friendly", Description = "" },
               new Type { Name = "Movie", Description = "" },
               new Type { Name = "Party", Description = "" }
            };

         new List<Event>
            {
               new Event { Title = "Be a Winner at the Diner!", Type = type.Single(a => a.Name == "Singles"), StartDate = DateTime.Parse("11/06/1993"), EndDate = DateTime.Parse("11/06/1993"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Tony Stark"), Description = "Come meet other singles!", MaxTickets = 50, AvailableTickets = 50  }

            }.ForEach(a => context.Events.Add(a));

      }
   }
}