using System.Web;
using System.Web.Mvc;

namespace IT2030_Lab8_MeganOstrander_Authorization
{
   public class FilterConfig
   {
      public static void RegisterGlobalFilters(GlobalFilterCollection filters)
      {
         filters.Add(new AuthorizeAttribute()); //forces ALL users to login before using website
         filters.Add(new HandleErrorAttribute());
      }
   }
}
