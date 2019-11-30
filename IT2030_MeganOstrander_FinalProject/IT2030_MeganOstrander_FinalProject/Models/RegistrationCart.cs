using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT2030_MeganOstrander_FinalProject.Models
{
   public class RegistrationCart
   {

      public String RegistrationCartId;


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

         string OrderId;

         //look at session state
         if (context.Session[CartSessionId] == null)
         {
            //if not exist
            //create new cart id
            //save to session state

            if(!string.IsNullOrWhiteSpace(context.User.Identity.Name))
            {
               //obtain information from user login
               OrderId = context.User.Identity.Name;

               //save to the session date
               context.Session[CartSessionId] = OrderId;
            }

         }
         else
         {
            //if exist
            //return the cart id

            OrderId = context.Session[CartSessionId].ToString();

         }


         return OrderId;
      }


      public List<Cart> GetCartItems()
      {
         return db.Carts
            .Where(c => c.OrderId == this.RegistrationCartId)
            .ToList();

      }


      public void AddToCart(int eventId)
      {
         //verify that the event id exists in the database


         //if it finds item in cart, rturn that. else return null
         Cart cartItem = db.Carts.SingleOrDefault(c => c.OrderId == this.RegistrationCartId && c.EventId == eventId);

         if (cartItem == null)
         {
            // item is not in cart, add new item
            cartItem = new Cart()
            {
               OrderId = this.RegistrationCartId,
               EventId = eventId,
               Quantity = 1,
               DateOrdered = DateTime.Now
            };

            db.Carts.Add(cartItem);

         }
         else
         {
            // item is in cart, increase item count
            cartItem.Quantity = cartItem.Quantity + 1;
         }

         //tells database to persist the changes
         db.SaveChanges();

      }


      public int RemoveFromCart(int recordId)
      {
         //verify that the album id exists in the database


         //if it finds item in cart, rturn that. else return null
         Cart cartItem = db.Carts.SingleOrDefault(c => c.OrderId == this.RegistrationCartId && c.EventId == recordId);

         if (cartItem == null)
         {
            // item is not in cart, throw null exception
            throw new NullReferenceException();

         }

         int newCount;

         if (cartItem.Quantity > 1)
         {
            // item is in cart & count > 1, decrease count
            cartItem.Quantity--;
            newCount = cartItem.Quantity;
         }
         else
         {
            //if count = 0, remove item completely
            db.Carts.Remove(cartItem);
            newCount = 0;
         }


         //tells database to persist the changes
         db.SaveChanges();

         return newCount;
      }

   }//end of shopping cart class
}