﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IT2030_MeganOstrander_FinalProject.Models
{
   //Using "DropCreateDatabaseAlways" enables the sample data to actually be used! If you use "IfDatabaseChanges" instead, it will not use the sample data!
   public class SampleData : DropCreateDatabaseAlways<EventsDBContext>
   {
      protected override void Seed(EventsDBContext context)
      {
         var organizers = new List<Organizer>
            {
                new Organizer { Name = "Molly Whitmen", ContactInfo = "444-388-6544" },
                new Organizer { Name = "Tony Stark", ContactInfo = "779-668-9556"  },
                new Organizer { Name = "Jessica Simpson", ContactInfo = "874-689-3356"  },
                new Organizer { Name = "Usagi Tsukino", ContactInfo = "289-645-1158"  },
                new Organizer { Name = "Mercer Frey", ContactInfo = "121-388-2603"  },
                new Organizer { Name = "Annabell", ContactInfo = "722-351-2885"  }
            };

         var type = new List<Type>
            {
               new Type { Name = "Child Friendly", Description = "" },
               new Type { Name = "Concert", Description = "" },
               new Type { Name = "Couples", Description = "" },
               new Type { Name = "Expo", Description = "" },
               new Type { Name = "Fundraiser", Description = "" },
               new Type { Name = "Gala", Description = "" },
               new Type { Name = "Movie", Description = "" },
               new Type { Name = "Party", Description = "" },
               new Type { Name = "Seminar", Description = "" },
               new Type { Name = "Singles", Description = "" },
               new Type { Name = "Other", Description = ""}
            };

         //NOTE: You CANNOT use the id numbers for type and organizer, it will not work! Have to use the actual names.
         new List<Event>
            {
               new Event { Title = "Be a Winner at the Diner!", Type = type.Single(a => a.Name == "Singles"), StartDate = DateTime.Parse("12/10/2019"), EndDate = DateTime.Parse("12/10/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Tony Stark"), Description = "Come meet other singles!", MaxTickets = 50, AvailableTickets = 0  },
               new Event { Title = "Singles Dinner", Type = type.Single(a => a.Name == "Couples"), StartDate = DateTime.Parse("12/11/2019"), EndDate = DateTime.Parse("12/11/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("10 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Molly Whitmen"), Description = "", MaxTickets = 50, AvailableTickets = 40  },
               new Event { Title = "Astrophysics", Type = type.Single(a => a.Name == "Seminar"), StartDate = DateTime.Parse("12/05/2019"), EndDate = DateTime.Parse("12/05/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Usagi Tsukino"), Description = "", MaxTickets = 50, AvailableTickets = 30  },
               new Event { Title = "Antebella Concert", Type = type.Single(a => a.Name == "Singles"), StartDate = DateTime.Parse("12/07/2019"), EndDate = DateTime.Parse("12/07/2019"), StartTime = DateTime.Parse("4 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Mercer Frey"), Description = "", MaxTickets = 50, AvailableTickets = 25  },
               new Event { Title = "Romantic Dinner for Two", Type = type.Single(a => a.Name == "Couples"), StartDate = DateTime.Parse("12/01/2019"), EndDate = DateTime.Parse("12/01/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("10 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Usagi Tsukino"), Description = "", MaxTickets = 50, AvailableTickets = 28  },
               new Event { Title = "Come Meet Others", Type = type.Single(a => a.Name == "Singles"), StartDate = DateTime.Parse("12/02/2019"), EndDate = DateTime.Parse("12/02/2019"), StartTime = DateTime.Parse("5 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Jessica Simpson"), Description = "", MaxTickets = 50, AvailableTickets = 37  },
               new Event { Title = "Furries", Type = type.Single(a => a.Name == "Party"), StartDate = DateTime.Parse("12/25/2019"), EndDate = DateTime.Parse("12/25/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("9 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Mercer Frey"), Description = "", MaxTickets = 50, AvailableTickets = 46  },
               new Event { Title = "Cats 101", Type = type.Single(a => a.Name == "Singles"), StartDate = DateTime.Parse("12/27/2019"), EndDate = DateTime.Parse("12/27/2019"), StartTime = DateTime.Parse("3 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Annabell"), Description = "", MaxTickets = 50, AvailableTickets = 50  },
               new Event { Title = "Dating 101", Type = type.Single(a => a.Name == "Singles"), StartDate = DateTime.Parse("12/11/2019"), EndDate = DateTime.Parse("12/11/2019"), StartTime = DateTime.Parse("4 pm"), EndTime = DateTime.Parse("9 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Mercer Frey"), Description = "", MaxTickets = 50, AvailableTickets = 49  },
               new Event { Title = "Writing 101", Type = type.Single(a => a.Name == "Other"), StartDate = DateTime.Parse("12/13/2019"), EndDate = DateTime.Parse("12/13/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("10 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Tony Stark"), Description = "", MaxTickets = 50, AvailableTickets = 10  },
               new Event { Title = "Book Club", Type = type.Single(a => a.Name == "Other"), StartDate = DateTime.Parse("12/15/2019"), EndDate = DateTime.Parse("12/15/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Molly Whitmen"), Description = "", MaxTickets = 50, AvailableTickets = 0  },
               new Event { Title = "Be a Winner at the Diner!", Type = type.Single(a => a.Name == "Couples"), StartDate = DateTime.Parse("12/02/2019"), EndDate = DateTime.Parse("12/02/2019"), StartTime = DateTime.Parse("5 pm"), EndTime = DateTime.Parse("7 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Mercer Frey"), Description = "", MaxTickets = 50, AvailableTickets = 40  },
               new Event { Title = "Advanced Pool", Type = type.Single(a => a.Name == "Seminar"), StartDate = DateTime.Parse("12/03/2019"), EndDate = DateTime.Parse("12/03/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("8 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Tony Stark"), Description = "", MaxTickets = 50, AvailableTickets = 50  },
               new Event { Title = "Book Club", Type = type.Single(a => a.Name == "Movie"), StartDate = DateTime.Parse("12/04/2019"), EndDate = DateTime.Parse("12/04/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Annabell"), Description = "", MaxTickets = 50, AvailableTickets = 0  },
               new Event { Title = "Taylor Swift Concert", Type = type.Single(a => a.Name == "Concert"), StartDate = DateTime.Parse("12/10/2019"), EndDate = DateTime.Parse("12/10/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("8 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Tony Stark"), Description = "", MaxTickets = 50, AvailableTickets = 21  },
               new Event { Title = "Evanescence Concert", Type = type.Single(a => a.Name == "Concert"), StartDate = DateTime.Parse("12/11/2019"), EndDate = DateTime.Parse("12/11/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("7 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Tony Stark"), Description = "", MaxTickets = 50, AvailableTickets = 30  },
               new Event { Title = "Writer's Greeting", Type = type.Single(a => a.Name == "Singles"), StartDate = DateTime.Parse("12/14/2019"), EndDate = DateTime.Parse("12/14/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Usagi Tsukino"), Description = "", MaxTickets = 50, AvailableTickets = 50  },
               new Event { Title = "Book Signing", Type = type.Single(a => a.Name == "Other"), StartDate = DateTime.Parse("12/10/2019"), EndDate = DateTime.Parse("12/10/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("9 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Molly Whitmen"), Description = "", MaxTickets = 50, AvailableTickets = 10  },
               new Event { Title = "Swimming Theory", Type = type.Single(a => a.Name == "Singles"), StartDate = DateTime.Parse("12/19/2019"), EndDate = DateTime.Parse("12/19/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Tony Stark"), Description = "", MaxTickets = 50, AvailableTickets = 11  },
               new Event { Title = "Learn How to Cope", Type = type.Single(a => a.Name == "Seminar"), StartDate = DateTime.Parse("12/18/2019"), EndDate = DateTime.Parse("12/18/2019"), StartTime = DateTime.Parse("5 pm"), EndTime = DateTime.Parse("9 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Usagi Tsukino"), Description = "", MaxTickets = 50, AvailableTickets = 0  },
               new Event { Title = "Karaoke", Type = type.Single(a => a.Name == "Party"), StartDate = DateTime.Parse("12/10/2019"), EndDate = DateTime.Parse("12/10/2019"), StartTime = DateTime.Parse("4 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Tony Stark"), Description = "", MaxTickets = 50, AvailableTickets = 24  },
               new Event { Title = "Overcome Anxiety", Type = type.Single(a => a.Name == "Movie"), StartDate = DateTime.Parse("12/16/2019"), EndDate = DateTime.Parse("12/16/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("10 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Jessica Simpson"), Description = "", MaxTickets = 50, AvailableTickets = 13  },
               new Event { Title = "Interviewing 101", Type = type.Single(a => a.Name == "Singles"), StartDate = DateTime.Parse("12/10/2019"), EndDate = DateTime.Parse("12/10/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Tony Stark"), Description = "", MaxTickets = 50, AvailableTickets = 18  },
               new Event { Title = "Book Signing", Type = type.Single(a => a.Name == "Other"), StartDate = DateTime.Parse("12/11/2019"), EndDate = DateTime.Parse("12/11/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Molly Whitmen"), Description = "", MaxTickets = 50, AvailableTickets = 24  },
               new Event { Title = "Romantic Picnic", Type = type.Single(a => a.Name == "Singles"), StartDate = DateTime.Parse("12/10/2019"), EndDate = DateTime.Parse("12/10/2019"), StartTime = DateTime.Parse("3 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Annabell"), Description = "", MaxTickets = 50, AvailableTickets = 23  },
               new Event { Title = "Disney Night", Type = type.Single(a => a.Name == "Child Friendly"), StartDate = DateTime.Parse("12/12/2019"), EndDate = DateTime.Parse("12/12/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("7 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Jessica Simpson"), Description = "", MaxTickets = 50, AvailableTickets = 10  },
               new Event { Title = "Dinner Party", Type = type.Single(a => a.Name == "Party"), StartDate = DateTime.Parse("12/10/2019"), EndDate = DateTime.Parse("12/10/2019"), StartTime = DateTime.Parse("2 pm"), EndTime = DateTime.Parse("9 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Tony Stark"), Description = "", MaxTickets = 50, AvailableTickets = 0  },
               new Event { Title = "Gala Training", Type = type.Single(a => a.Name == "Gala"), StartDate = DateTime.Parse("12/10/2019"), EndDate = DateTime.Parse("12/10/2019"), StartTime = DateTime.Parse("3 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Molly Whitmen"), Description = "", MaxTickets = 50, AvailableTickets = 9  },
               new Event { Title = "BackStreet Boys Concert", Type = type.Single(a => a.Name == "Concert"), StartDate = DateTime.Parse("12/10/2019"), EndDate = DateTime.Parse("12/10/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("10 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Tony Stark"), Description = "", MaxTickets = 50, AvailableTickets = 2  },
               new Event { Title = "Be a Winner at the Diner!", Type = type.Single(a => a.Name == "Singles"), StartDate = DateTime.Parse("11/30/2019"), EndDate = DateTime.Parse("11/30/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Usagi Tsukino"), Description = "", MaxTickets = 50, AvailableTickets = 7  },
               new Event { Title = "Singles Dinner", Type = type.Single(a => a.Name == "Singles"), StartDate = DateTime.Parse("12/02/2019"), EndDate = DateTime.Parse("12/02/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("6 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Tony Stark"), Description = "", MaxTickets = 50, AvailableTickets = 0  },
               new Event { Title = "Zombie Land", Type = type.Single(a => a.Name == "Singles"), StartDate = DateTime.Parse("12/10/2019"), EndDate = DateTime.Parse("12/10/2019"), StartTime = DateTime.Parse("4 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Mercer Frey"), Description = "", MaxTickets = 50, AvailableTickets = 0  },
               new Event { Title = "Laser Tag", Type = type.Single(a => a.Name == "Child Friendly"), StartDate = DateTime.Parse("11/13/2019"), EndDate = DateTime.Parse("11/13/2019"), StartTime = DateTime.Parse("8 pm"), EndTime = DateTime.Parse("10 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Tony Stark"), Description = "", MaxTickets = 50, AvailableTickets = 5  },
               new Event { Title = "Gamer's Night", Type = type.Single(a => a.Name == "Expo"), StartDate = DateTime.Parse("11/15/2019"), EndDate = DateTime.Parse("11/15/2019"), StartTime = DateTime.Parse("6 pm"), EndTime = DateTime.Parse("6 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Jessica Simpson"), Description = "", MaxTickets = 50, AvailableTickets = 3  },
               new Event { Title = "Be a Winner at the Diner!", Type = type.Single(a => a.Name == "Singles"), StartDate = DateTime.Parse("11/10/2019"), EndDate = DateTime.Parse("11/10/2019"), StartTime = DateTime.Parse("9 pm"), EndTime = DateTime.Parse("11 pm"), Location = "Starlight Diner", Organizer = organizers.Single(a => a.Name == "Mercer Frey"), Description = "", MaxTickets = 50, AvailableTickets = 14  }
            }.ForEach(a => context.Events.Add(a));

      }
   }
}