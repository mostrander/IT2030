using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT2030_MeganOstrander_FinalProject.Models;

namespace IT2030_MeganOstrander_FinalProject.Controllers
{
   [Authorize]
    public class RegistrationCartController : Controller
    {
      EventsDBContext db = new EventsDBContext();

      // GET: ShoppingCart/Index
      //Tickets Ordered Page
      public ActionResult Index()
      {
         RegistrationCart cart = RegistrationCart.GetCart(this.HttpContext);

         RegistrationCartViewModel vm = new RegistrationCartViewModel()
         {
            CartItems = cart.GetCartItems()
         };

         return View(vm);
      }

      //???
      public ViewResult Orders()
      {
         return View();
      }

      //GET: ShoppingCart//AddToCart
      public ActionResult AddToCart(int id)
      {
         RegistrationCart cart = RegistrationCart.GetCart(this.HttpContext);

         cart.AddToCart(id);

         return RedirectToAction("Index"); //redirects user to index page
      }

      // POST: ShoppingCart/RemoveFromCart
      [HttpPost]
      public ActionResult RemoveFromCart(int id)
      {

         RegistrationCart cart = RegistrationCart.GetCart(this.HttpContext);

         Event eventSelected = db.Carts.SingleOrDefault(c => c.RecordId == id).EventSelected;

         int newItemCount = cart.RemoveFromCart(id);


         DeleteCartViewModel vm = new DeleteCartViewModel()
         {
            DeleteId = id,
            ItemCount = newItemCount,
            Message = eventSelected.Title + " has been removed from the cart"
         };

         return Json(vm);


         //error that allows code to compile still
         //throw new NotImplementedException();
      }

   }


}
