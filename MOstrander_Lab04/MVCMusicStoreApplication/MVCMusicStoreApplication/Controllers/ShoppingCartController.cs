using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStoreApplication.Models;

namespace MVCMusicStoreApplication.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
         ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);

         ShoppingCartViewModel vm = new ShoppingCartViewModel()
         {
            CartItems = cart.GetCartItems(),
            CartTotal = cart.GetCartTotal()

         };


            return View(vm);
        }

      //GET: ShoppingCart//AddToCart
      public ActionResult AddToCart()
      {
         ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);

         throw new NotImplementedException();
      }

      // POST: ShoppingCart/RemoveFromCart
      [HttpPost]
      public ActionResult RemoveFromCart ()
      {
         //error that allows code to compile still
         throw new NotImplementedException();
      }

    }
}