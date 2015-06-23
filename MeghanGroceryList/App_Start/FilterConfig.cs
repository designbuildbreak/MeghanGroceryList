using MeghanGroceryList.Models;
using System.Web;
using System.Web.Mvc;

namespace MeghanGroceryList
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            bool basicAuthenticationEnabled = true;

            if (basicAuthenticationEnabled)
                filters.Add(new BasicAuthenticationAttribute());

            filters.Add(new HandleErrorAttribute());
        }
    }
}
