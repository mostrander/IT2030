using System.Web;
using System.Web.Mvc;

namespace IT2030_MeganOstrander_FinalProject
{
   public class FilterConfig
   {
      public static void RegisterGlobalFilters(GlobalFilterCollection filters)
      {
         filters.Add(new HandleErrorAttribute());
      }
   }
}
