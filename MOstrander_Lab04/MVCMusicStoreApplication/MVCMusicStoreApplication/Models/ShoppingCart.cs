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



   }

   
}