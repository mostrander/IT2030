using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStoreApplication.Models
{
   public class ShoppingCart
   {
      public string ShoppingCartId;

      private MVCMusicStoreDB db = new MVCMusicStoreDB();


      //method 
      public static ShoppingCart GetCart(HttpContextBase context)
      {
         ShoppingCart cart = new ShoppingCart();
         cart.ShoppingCartId = cart.GetCartId(context);
         return cart;
      }


      private string GetCartId(HttpContextBase context)
      {
         //constant
         const string CartSessionId = "CartId";

         string cartId;

         //look at session state
         if(context.Session[CartSessionId] == null)
         {
            //if not exist
            //create new cart id
            //save to session state

            cartId = Guid.NewGuid().ToString();

            //save to the session date
            context.Session[CartSessionId] = cartId;

         }
         else
         {
            //if exist
            //return the cart id

            cartId = context.Session[CartSessionId].ToString();

         }
         

         return cartId;
      }


      public List<Cart> GetCartItems()
      {
         return db.Carts
            .Where(c => c.CartId == this.ShoppingCartId)
            .ToList();

      }


      public decimal GetCartTotal()
      {
         decimal? total = (from cartItem in db.Carts
                     .Where(c => c.CartId == this.ShoppingCartId)
                     select cartItem.AlbumSelected.Price * (int?)cartItem.Count).Sum(); //sum of all items in cart (int?) makes it nullable

         // return total.HasValue ? total.Value : decimal.Zero; //if it has value, else return zero

         return total ?? decimal.Zero; //condensed version of previous
      }


      public void AddToCart(int albumId)
      {
         //verify that the album id exists in the database


         //if it finds item in cart, rturn that. else return null
         Cart cartItem = db.Carts.SingleOrDefault(c => c.CartId == this.ShoppingCartId && c.AlbumId == albumId);

         if(cartItem == null)
         {
            // item is not in cart, add new item
            cartItem = new Cart()
            {
               CartId = this.ShoppingCartId,
               AlbumId = albumId,
               Count = 1,
               DateCreated = DateTime.Now
            };

            db.Carts.Add(cartItem);

         }
         else
         {
            // item is in cart, increase item count
            cartItem.Count = cartItem.Count + 1;
         }

         //tells database to persist the changes
         db.SaveChanges();

      }


      public int RemoveFromCart(int recordId)
      {
         //verify that the album id exists in the database


         //if it finds item in cart, rturn that. else return null
         Cart cartItem = db.Carts.SingleOrDefault(c => c.CartId == this.ShoppingCartId && c.RecordId == recordId);

         if (cartItem == null)
         {
            // item is not in cart, throw null exception
            throw new NullReferenceException();

         }

         int newCount;

         if(cartItem.Count > 1)
         {
            // item is in cart & count > 1, decrease count
            cartItem.Count--;
            newCount = cartItem.Count;
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