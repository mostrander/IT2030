using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT2030_MeganOstrander_FinalProject.Models
{
   public class RegistrationCart
   { 

      public String RegistrationCartId;
      int RecordId;

      private EventsDBContext db = new EventsDBContext();


      //method 
      public static RegistrationCart GetCart(HttpContextBase context)
      {
         RegistrationCart cart = new RegistrationCart();
         cart.RegistrationCartId = cart.GetCartId(context);
         return cart;
      }


      private string GetCartId(HttpContextBase context)
      {
         //constant
         const string CartSessionId = "OrderId";

         string orderId = null;

         //look at session state
         if (context.Session[CartSessionId] == null)
         {
            //if not exist
            //create new cart id
            //save to session state

            if(!string.IsNullOrWhiteSpace(context.User.Identity.Name))
            {
               //obtain information from user login
               orderId = context.User.Identity.Name;

               //save to the session date
               context.Session[CartSessionId] = orderId;
            }

         }
         else
         {
            //if exist
            //return the cart id

            orderId = context.Session[CartSessionId].ToString();

         }


         return orderId;
      }


      public List<Cart> GetCartItems()
      {
         return db.Carts
            .Where(c => c.OrderId == this.RegistrationCartId)
            .ToList();

      }

      
      public void AddToCart(int eventId)
      {
         //generate a random number for each new set of tickets ordered
         Random number = new Random();

         RecordId = number.Next();

         //verify that the event id exists in the database


         //if it finds item in cart, return that. else return null
         Cart cartItem = db.Carts.SingleOrDefault(c => c.RecordId == this.RecordId && c.EventId == eventId);

         Event eventSelected = db.Events.Find(eventId);

         //if (cartItem == null)
         //{
            // item is not in cart, add new item
            cartItem = new Cart()
            {
               RecordId = number.Next(),
               OrderId = this.RegistrationCartId,
               EventId = eventId,
               QuantityOrdered = 1,
               DateOrdered = DateTime.Now,
               Status = "Processed"
            };

            eventSelected.AvailableTickets = eventSelected.AvailableTickets - cartItem.QuantityOrdered; //decrease available tickets for that event

            db.Carts.Add(cartItem);
            
         //}

         //else
         //{
         //   // item is in cart, increase item count
         //   cartItem.Quantity = cartItem.Quantity + 1;
         //   cartItem.EventSelected.AvailableTickets--; //decrease available tickets for that event 
         //}

         //tells database to persist the changes
         db.SaveChanges();

      }


      public int RemoveFromCart(int recordId)
      {
         //verify that the record id exists in the database


         //if it finds item in cart, return that. else return null
         Cart cartItem = db.Carts.SingleOrDefault(c => c.OrderId == this.RegistrationCartId && c.RecordId == recordId);

         if (cartItem == null)
         {
            // item is not in cart, throw null exception
            throw new NullReferenceException();

         }

         int newCount = cartItem.QuantityOrdered;

         cartItem.EventSelected.AvailableTickets = cartItem.EventSelected.AvailableTickets + newCount; //increase available tickets back to original amount

         if (cartItem.QuantityOrdered > 1)
         {
            // item is in cart & count > 1, decrease count
            cartItem.QuantityOrdered = 0;

            newCount = cartItem.QuantityOrdered;
            
         }
         else
         {
            //if count = 0, remove item completely
            newCount = 0;
            cartItem.Status = "Cancelled";
         }

         //tells database to persist the changes
         db.SaveChanges();

         return newCount;
      }

   }//end of shopping cart class
}